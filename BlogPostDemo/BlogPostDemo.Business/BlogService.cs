using System;
using System.Collections.Generic;
using System.Text;
using BlogPostDemo.Contracts;
using BlogPostDemo.Models;
using System.Linq;
namespace BlogPostDemo.Business
{
    public class BlogService : IBlogService
    {
        #region private fields
        private List<Blog> _blogs;
        #endregion

        #region constructor
        public BlogService()
        {
            _blogs = new List<Blog>();
           
            _blogs.Add(new Blog() {
                Id = 1,
                Title = "Angular",
                Author = "Satya",
                DateCreated = DateTime.Now
            });
        }
        #endregion
        public void AddBlog(Blog blog)
        {
            _blogs.Add(blog);
        }

        public void DeleteBlog(int id)
        {
            var blog = _blogs.Where(b => b.Id == id).FirstOrDefault();
            _blogs.Remove(blog);
        }

        public Blog GetBlogById(int id)
        {
            var blog = _blogs.Where(b => b.Id == id).FirstOrDefault();
            return blog;
        }

        public List<Blog> GetBlogs()
        {
            return _blogs;
        }

        public void UpdateBlog(Blog blog)
        {
            var returnBlog = _blogs.Where(b => b.Id == blog.Id).FirstOrDefault();
            if(returnBlog != null)
            {
                _blogs.Remove(returnBlog);
                _blogs.Add(blog);
            }
        }
    }
}
