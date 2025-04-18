﻿using AutoMapper;
using DeveloperStore.Api.ViewModels;
using DeveloperStore.Business.Functions;
using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController(ICommentService commentService,
                               IPostService postService,
                               IMapper mapper, 
                               INotifier notifier) : MainController(notifier)
{
    private readonly ICommentService _commentService = commentService;
    private readonly IPostService _postService = postService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sellerId = GeneralFunctions.GetUserIdFromToken(Request.Headers.Authorization.ToString());

        var comments = await _commentService.GetAllAsync(sellerId);

        var viewModel = _mapper.Map<IEnumerable<CommentViewModel>>(comments);
        return Ok(viewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var comment = await _commentService.GetByIdAsync(id);
        if (comment == null)
        {
            ReportError("This comment does not exist.");
            return CustomResponse();
        }

        var viewModel = _mapper.Map<CommentViewModel>(comment);
        return Ok(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CommentViewModel commentViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var post = await _postService.GetByIdAsync(commentViewModel.PostId);
        if (post == null)
        {
            ReportError("The comment post ID does not exist, please insert an existing post");
            return CustomResponse();
        }

        var comment = _mapper.Map<Comment>(commentViewModel);
        await _commentService.AddAsync(comment);
        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, commentViewModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CommentViewModel commentViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != commentViewModel.Id) return BadRequest("Mismatched comment ID");

        var post = await _postService.GetByIdAsync(commentViewModel.PostId);
        if (post == null)
        {
            ReportError("This post does not exist");
            return CustomResponse();
        }

        var commentValidate = await _commentService.GetByIdAsync(id);
        if (commentValidate == null)
        {
            ReportError("This comment does not exist.");
            return CustomResponse();
        }

        var comment = _mapper.Map<Comment>(commentViewModel);

        var sellerId = GeneralFunctions.GetUserIdFromToken(Request.Headers.Authorization.ToString());

        await _commentService.UpdateAsync(comment, sellerId);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var commentValidate = await _commentService.GetByIdAsync(id);
        if (commentValidate == null)
        {
            ReportError("This comment does not exist.");
            return CustomResponse();
        }

        var sellerId = GeneralFunctions.GetUserIdFromToken(Request.Headers.Authorization.ToString());

        await _commentService.DeleteAsync(id, sellerId);
        return NoContent();
    }
}