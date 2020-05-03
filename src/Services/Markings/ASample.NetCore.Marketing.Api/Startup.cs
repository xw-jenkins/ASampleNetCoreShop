using ASample.NetCore.Authentications;
using ASample.NetCore.Redis;
using ASample.NetCore.RelationalDb;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASample.NetCore.Marketing.Api
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddJwt();
            //sqlserver 数据库
            services.Configure<DbOptions>(Configuration.GetSection("sql"));
            services.AddRelationalDb<MarketingApiContext>();
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

            services.AddMvc(
                option =>
                {
                    option.Filters.Add<UnitOfWorkExecute>();
                }).AddJsonOptions(opt => {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

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
    }
}
