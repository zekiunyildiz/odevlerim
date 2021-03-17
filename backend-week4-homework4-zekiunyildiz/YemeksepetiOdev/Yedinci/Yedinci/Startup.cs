using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;
using Yedinci.Controllers;
using Yedinci.Models;
namespace Yedinci
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("Yedinci"));
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                
                options.ApiVersionReader = new HeaderApiVersionReader("version");
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;

                options.Conventions.Controller<FootballTeamsController>().HasApiVersion(1, 0).HasApiVersion(1, 1);
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
