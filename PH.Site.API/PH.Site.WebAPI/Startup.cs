using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using PH.Site.IRepository;
using PH.Site.Repository;
using PH.Site.WebAPI.Filter;
using PH.Site.WebAPI.Middleware;
using Swashbuckle.AspNetCore.Swagger;

namespace PH.Site.WebAPI
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
            services
                .AddCors(opt =>
                {
                    //设置跨域
                    opt.AddPolicy("any", builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
                })
                .AddMvc(opt =>
                {
                    //配置过滤器
                    opt.Filters.Add<ValidationModelFilter>();
                })
                .AddJsonOptions(opt =>
                {
                    //配置默认返回格式
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Swagger配置
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "PH.Site.API",
                    Description = "WebAPI for PH.Site",
                    Contact = new Contact
                    {
                        Name = "预览地址",
                        Email = string.Empty,
                        Url = "http://pinhua.site"
                    },
                    License = new License
                    {
                        Name = "GitHub",
                        Url = "https://github.com/eyu1993/PH.Site"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //依赖注入
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
                app.UseHsts();
            }
            app.UseCors("any");

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PH.Site.WebAPI");
                c.RoutePrefix = "help";
            });

            app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));


            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
