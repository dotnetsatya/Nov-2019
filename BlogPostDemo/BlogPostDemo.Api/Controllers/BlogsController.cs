using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogPostDemo.Models;
using BlogPostDemo.Contracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogPostDemo.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/blog-management/")]
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
        public ActionResult<List<Blog>> Get()
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
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public ActionResult<Blog> GetById([Required] [FromQuery] int id, [FromQuery] string name)
        {
            var blog = _blogService.GetBlogById(id);
            if(blog == null)
            {
                return NotFound("No data found");
            }

            return Ok(blog);
        }

        /// <summary>
        /// Save Blog
        /// </summary>
        /// <param name="blog">You need to pass blog object</param>
        [HttpPost]
        [Route("blogs")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddBlog(Blog blog)
        {
            if(!IsBlogValid(blog))
            {
                return BadRequest("Invalid Input model");
            }

            _blogService.AddBlog(blog);
            return Ok(blog);
        }

        private bool IsBlogValid(Blog blog)
        {
            if(blog.Id > 0 && blog.Title !=null && blog.Author != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
