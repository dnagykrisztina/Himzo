using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Himzo.Dal;
using Himzo.Dal.Entities;
using Himzo.Dal.SeedInterfaces;
using Himzo.Dal.SeedService;

namespace Himzo.Web
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
            services.AddControllers();
            services.AddDbContext<HimzoDbContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString(nameof(HimzoDbContext))));
            services.AddIdentity<User, Role>().
                AddEntityFrameworkStores<HimzoDbContext>();
            services.AddScoped<IUserSeedService, UserSeedService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
