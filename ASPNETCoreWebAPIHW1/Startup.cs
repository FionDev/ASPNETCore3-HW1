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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebAPIHW1.Models;

namespace ASPNETCoreWebAPIHW1
{
    public class Startup
    {
         public static readonly ILoggerFactory MyLoggerFactory=LoggerFactory.Create(build=>{
            build.AddConsole();
        });
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContosouniversityContext>(options =>
             options
             .UseLoggerFactory(MyLoggerFactory)
             .UseSqlServer(Configuration.GetConnectionString("ContosouniversityConn")));
             
            services.AddControllers();//預設使用System.Text.Json
            //services.AddControllers().AddNewtonsoftJson();//使用 .NET Core 3.1 內建的 System.Text.Json 命名空間處理 JSON 序列化
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
