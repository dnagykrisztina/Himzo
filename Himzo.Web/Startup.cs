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
using Microsoft.OpenApi.Models;

namespace Himzo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object UIFramework { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<HimzoDbContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString(nameof(HimzoDbContext))));
            services.AddIdentity<User, Role>().
                AddEntityFrameworkStores<HimzoDbContext>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigins",
                builder =>
                {
                    builder.WithOrigins("https://accounts.google.com");
                });
            });

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "955067358940-useatbvb53ek23cora7tcrufngvf14mc.apps.googleusercontent.com";
                    options.ClientSecret = "0t-axPW-a08nwuxJep5xtCF3";
                });
            services.AddScoped<IUserSeedService, UserSeedService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Himzo API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Himzo API V1");
            });

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseAuthentication();
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("general/signin.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
