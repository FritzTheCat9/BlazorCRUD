using BlazorCRUD.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostAsync(int postId);
        Task<bool> UpdatePostAsync(Post postToUpdate);
        Task<bool> CreatePostAsync(Post postToCreate);
        Task<bool> DeletePostAsync(int postId);
    }
}
