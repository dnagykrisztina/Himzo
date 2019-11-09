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
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;

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
                    options.ClientId = Configuration["Google:ClientId"];
                    options.ClientSecret = Configuration["Google:ClientSecret"];
                })
                .AddFacebook(options =>
                {
                    options.AppId = Configuration["Facebook:AppId"];
                    options.AppSecret = Configuration["Facebook:AppSecret"];
                })
                .AddMicrosoftAccount(options =>
                {
                    options.ClientId = Configuration["Microsoft:ClientId"];
                    options.ClientSecret = Configuration["Microsoft:ClientSecret"];
                })
				.AddOAuth("AuthSch", options =>
				{
					options.ClientId = Configuration["AuthSch:ClientId"];
					options.ClientSecret = Configuration["AuthSch:ClientSecret"];
					options.CallbackPath = new PathString("/signin-authsch");

					options.AuthorizationEndpoint = "https://auth.sch.bme.hu/site/login";
					options.TokenEndpoint = "https://auth.sch.bme.hu/oauth2/token";
					options.UserInformationEndpoint = "https://auth.sch.bme.hu/api/profile";

					options.SaveTokens = true;
					options.Scope.Add("displayName");
					options.Scope.Add("mail");

					options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "mail");
					options.ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");
					options.ClaimActions.MapJsonKey(ClaimTypes.Email, "mail");

					options.Events = new OAuthEvents
					{
						OnCreatingTicket = async context =>
						{
							var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint + "/?access_token=" + context.AccessToken);
							request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
							System.Console.WriteLine(context.AccessToken);

							var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
							response.EnsureSuccessStatusCode();

							var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
							context.RunClaimActions(user.RootElement);
						}
					};
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
            options.DefaultFileNames.Add("dist/index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles(); // For the wwwroot folder
            app.UseStaticFiles(new StaticFileOptions // js folder
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist", "js")),
                RequestPath = "/js"
            });
            app.UseStaticFiles(new StaticFileOptions // img folder
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist", "img")),
                RequestPath = "/img"
            });
            app.UseStaticFiles(new StaticFileOptions // css folder
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist", "css")),
                RequestPath = "/css"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
