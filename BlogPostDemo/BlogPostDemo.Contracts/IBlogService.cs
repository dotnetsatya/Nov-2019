using System;
using System.Collections.Generic;
using System.Text;
using BlogPostDemo.Models;

namespace BlogPostDemo.Contracts
{
    /// <summary>
    /// This contract is for Blog Service and methods
    /// </summary>
    public interface IBlogService
    {
        List<Blog> GetBlogs();

        Blog GetBlogById(int id);

        void AddBlog(Blog blog);

        void UpdateBlog(Blog blog);

        void DeleteBlog(int id);
    }
}
