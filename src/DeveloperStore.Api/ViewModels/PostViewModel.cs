﻿using System.Text.Json.Serialization;

namespace DeveloperStore.Api.ViewModels;

public class PostViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    [JsonIgnore] 
    public Guid SellerId { get; set; }
    public List<CommentViewModel> Comments { get; set; }
}