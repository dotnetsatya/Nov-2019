using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostDemo.Api.Controllers
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/blog-management/")]
    public class PostsController : ControllerBase
    {
        /// <summary>
        /// Get blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("blogs")]
        public string GetBlogs()
        {
            return "Hello v2";
        }
    }
}
