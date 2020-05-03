using ASample.NetCore.Authentications;
using ASample.NetCore.Redis;
using ASample.NetCore.RelationalDb;
using Autofac;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;
using Role = ASample.NetCore.Identity.Api.Domain.Role;
using User = ASample.NetCore.Identity.Api.Domain.User;

namespace ASample.NetCore.Identity.Api
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
            //services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddJwt();
            //sqlserver 数据库
            services.Configure<DbOptions>(Configuration.GetSection("sql"));
            services.AddRelationalDb<IdentityApiContext>();
            //services.AddRedis();
            services.AddAuthentication();
            services.AddCors(options =>
            {
                options.AddPolicy("any", b =>
                {
                    b.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    //.AllowCredentials();//指定处理cookie
                });
            });
            services.AddHttpContextAccessor();
            services.AddIdentity<User,Role>()
                // Adds UserStore and RoleStore from this context
                // That are consumed by the UserManager and RoleManager
                // https://github.com/aspnet/Identity/blob/dev/src/EF/IdentityEntityFrameworkBuilderExtensions.cs
                .AddEntityFrameworkStores<IdentityApiContext>()

                // Adds a provider that generates unique keys and hashes for things like
                // forgot password links, phone number verification codes etc...
                .AddDefaultTokenProviders();

            services.AddMvc(
                option =>
                {
                    option.Filters.Add<UnitOfWorkExecute>();
                }).AddJsonOptions(opt => {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //configure auto fac here
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                    .AsImplementedInterfaces();
            builder.AddCustomerRedis();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<IdentityApiContext>();
            //    context.Database.EnsureCreated();
            //}

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("any");
            app.UseAuthentication();
            app.UseAccessTokenValidator();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        static Func<RedirectContext<CookieAuthenticationOptions>, Task> ReplaceRedirector(HttpStatusCode statusCode,
            Func<RedirectContext<CookieAuthenticationOptions>, Task> existingRedirector) =>
            context =>
            {
                if (context.Request.Path.StartsWithSegments("/api"))
                {
                    context.Response.StatusCode = (int)statusCode;
                    return Task.CompletedTask;
                }
                return existingRedirector(context);
            };
    }
}
