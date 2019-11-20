using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPostDemo.Models
{
    /// <summary>
    /// This model is representing Blog
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// this is for primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This is the blog title
        /// </summary>
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
