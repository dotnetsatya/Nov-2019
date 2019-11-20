using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;




using BlogPostDemo.Api.Utilites;

namespace BlogPostDemo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDependencies();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "v1",
                        Title = "v1 API",
                        Description = "v1 API Description",
                        TermsOfService = "Terms of usage v1",
                        Contact = new Contact()
                        {
                            Name = "SAtya",
                            Url = "http://www.test.com"
                        },
                        License = new License()
                        {
                            Name = "Open Licence"
                        }
                    });

                // Add a SwaggerDoc for v2 
                options.SwaggerDoc("v2",
                    new Info
                    {
                        Version = "v2",
                        Title = "v2 API",
                        Description = "v2 API Description",
                        TermsOfService = "Terms of usage v3"
                    });


                options.AddSecurityDefinition("api-key", new ApiKeyScheme
                {
                    Description =
                    "API Key needed to access this API. Example: \"c9ea7f41-ccef-484a-a4be-c70367bca65f\"",
                    Name = "api-key",
                    In = "header",
                    Type = "apiKey"
                });

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "api-key", new string[] { } } });
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } } });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

            });

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
        });

        app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
