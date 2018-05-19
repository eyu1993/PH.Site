using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using PH.Site.IRepository;
using PH.Site.Repository;
using PH.Site.WebAPI.Filter;
using PH.Site.WebAPI.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

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
            services.AddMvc(opt =>
            {
                opt.Filters.Add<ValidationModelFilter>();
            }).AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "PH.Site.API",
                    Version = "v1",
                    License = new License { Name = "预览地址", Url = "http://pinhua.site" },
                    Contact = new Contact { Name = "Github", Email = "", Url = "https://github.com/eyu1993/PH.Site" }
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "PH.Site.WebAPI.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PH.Site.API V1");
                c.RoutePrefix = "help";
            });

            app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));
            app.UseMvc();
        }
    }
}
