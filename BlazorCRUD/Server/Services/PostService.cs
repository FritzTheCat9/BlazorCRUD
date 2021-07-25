using BlazorCRUD.Server.Data;
using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            var posts = await _dbContext.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostAsync(int postId)
        {
            var post = await _dbContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);
            return post;
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            var post = await _dbContext.Posts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == postToUpdate.Id);

            if (post == null)
                return false;

            _dbContext.Posts.Update(postToUpdate);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> CreatePostAsync(Post postToCreate)
        {
            _dbContext.Posts.Add(postToCreate);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await GetPostAsync(postId);

            if (post == null)
                return false;

            _dbContext.Posts.Remove(post);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
