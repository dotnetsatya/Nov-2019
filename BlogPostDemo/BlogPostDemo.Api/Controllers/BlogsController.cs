using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogPostDemo.Models;
using BlogPostDemo.Contracts;

namespace BlogPostDemo.Api.Controllers
{
    [ApiController]
    [Route("api/blog-management/")]
    ///<summary>
    ///This is a simple API for testing swagger
    ///</summary>
    public class BlogsController : ControllerBase
    {
        #region private fields
        private readonly IBlogService _blogService;
        #endregion

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
       
        /// <summary>
        /// Get blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("blogs")]
        public List<Blog> Get()
        {
            var blogs = _blogService.GetBlogs();

            return blogs;
        }

        /// <summary>
        /// GEt the Blog by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("blogs-s")]
        public Blog GetById([FromQuery] int id, [FromQuery] string name)
        {
            var blog = _blogService.GetBlogById(id);
            return blog;
        }

        /// <summary>
        /// Save Blog
        /// </summary>
        /// <param name="blog">You need to pass blog object</param>
        [HttpPost]
        [Route("blogs")]
        public void AddBlog(Blog blog)
        {
            _blogService.AddBlog(blog);
        }
    }
}
