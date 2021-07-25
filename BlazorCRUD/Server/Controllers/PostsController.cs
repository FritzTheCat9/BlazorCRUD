using BlazorCRUD.Server.Services;
using BlazorCRUD.Shared;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IUriService _uriService;

        public PostsController(IPostService postService, IUriService uriService)
        {
            _postService = postService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> GetById([FromRoute] int postId)
        {
            var post = await _postService.GetPostAsync(postId);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] Post postToCreate)
        {
            var post = new Post { Title = postToCreate.Title, Text = postToCreate.Text };

            await _postService.CreatePostAsync(post);
            var locationUri = _uriService.GetPostUri(post.Id);

            return Created(locationUri, post);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] int postId, [FromBody] Post postToUpdate)
        {
            var post = new Post
            {
                Id = postId,
                Title = postToUpdate.Title,
                Text = postToUpdate.Text
            };

            var updated = await _postService.UpdatePostAsync(post);

            if (updated)
                return Ok(post);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int postId)
        {
            var deleted = await _postService.DeletePostAsync(postId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
