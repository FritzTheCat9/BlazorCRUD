using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasData(new List<Post>
                    {
                        new Post { Id = 1, Title = "Post Title 1", Text = "Post text 1"},
                        new Post { Id = 2, Title = "Post Title 2", Text = "Post text 2"},
                        new Post { Id = 3, Title = "Post Title 3", Text = "Post text 3"},
                        new Post { Id = 4, Title = "Post Title 4", Text = "Post text 4"},
                        new Post { Id = 5, Title = "Post Title 5", Text = "Post text 5"}
                    });
        }
    }
}
