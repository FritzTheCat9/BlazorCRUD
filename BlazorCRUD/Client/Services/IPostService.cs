using BlazorCRUD.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostAsync(int postId);
        Task UpdatePostAsync(int postId, Post postToUpdate);
        Task CreatePostAsync(Post postToCreate);
        Task DeletePostAsync(int postId);
    }
}
