using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly:ApiController]
namespace ERP_System
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

            services.AddControllers()
                 .ConfigureApiBehaviorOptions(options=> {
                   // options.SuppressModelStateInvalidFilter = true;//disable automatic 400 response
                   // options.SuppressInferBindingSourcesForParameters=true; //disable inference  rule
                });
            services.AddCors();
            services.AddDbContext<Application_Identity_DbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ConnStr"));
                });
            services.Add_ERP_System_Authentication_Configuration(Configuration);
            services.Add_ApplicationRepositories();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP_System", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP_System v1"));
            }

            app.UseHttpsRedirection();
           
            app.UseRouting();
            app.UseCors(options =>
            {
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
            });
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
