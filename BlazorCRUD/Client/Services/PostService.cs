using BlazorCRUD.Shared;
using BlazorCRUD.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>(ApiRoutes.Posts.GetAll);
        }

        public async Task<Post> GetPostAsync(int postId)
        {
            return await _httpClient.GetFromJsonAsync<Post>(ApiRoutes.Posts.Get.Replace("{postId}", postId.ToString()));
        }

        public async Task CreatePostAsync(Post postToCreate)
        {
            await _httpClient.PostAsJsonAsync<Post>(ApiRoutes.Posts.Create, postToCreate);
        }

        public async Task UpdatePostAsync(int postId, Post postToUpdate)
        {
            await _httpClient.PutAsJsonAsync<Post>(ApiRoutes.Posts.Update.Replace("{postId}", postId.ToString()), postToUpdate);
        }

        public async Task DeletePostAsync(int postId)
        {
            await _httpClient.DeleteAsync(ApiRoutes.Posts.Delete.Replace("{postId}", postId.ToString()));
        }
    }
}
