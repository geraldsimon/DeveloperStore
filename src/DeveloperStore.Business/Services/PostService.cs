﻿using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Services
{
    public class PostService(IPostRepository postRepository) : IPostService
    {
        public async Task<IEnumerable<Post>> GetAllAsync(Guid sellerId)
        {
            return await postRepository.GetAllAsync(sellerId);
        }
        public async Task<Post> GetByIdAsync(Guid id)
        {
            return await postRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Post post)
        {
            await postRepository.AddAsync(post);
        }

        public async Task UpdateAsync(Post post, Guid sellerId)
        {
            var existingPost = await postRepository.GetByIdAsync(post.Id);

            if (existingPost == null)
            {
                throw new ArgumentException("Post not found.");
            }

            if (existingPost.SellerId != sellerId)
            {
                throw new UnauthorizedAccessException("You are not authorized to update this post.");
            }

            await postRepository.UpdateAsync(post);
        }

        public async Task DeleteAsync(Guid id, Guid sellerId)
        {
            var post = await postRepository.GetByIdAsync(id);

            if (post == null)
            {
                throw new ArgumentException("Post not found.");
            }

            if (post.SellerId != sellerId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this post.");
            }

            await postRepository.DeleteAsync(id);
        }
    }
}