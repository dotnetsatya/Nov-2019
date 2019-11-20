using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostDemo.Contracts;
using BlogPostDemo.Business;
using Microsoft.Extensions.DependencyInjection;

namespace BlogPostDemo.Api.Utilites
{
    public static class ServiceExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IBlogService, BlogService>();
            //add more
        }
    }
}
