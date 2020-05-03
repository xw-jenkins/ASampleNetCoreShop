using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Http;
using ASample.NetCore.Redis;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASample.NetCore.FileStorage.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("any", b =>
                {
                    b.AllowAnyOrigin() //�����κ���Դ����������
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    //.AllowCredentials();//ָ������cookie
                });
            });
            services.AddHttpContextAccessor();
            services.AddASampleHttpClient();
            services.AddAuthentication();
            services.AddMvc(
                option =>
                {
                    //option.Filters.Add<UnitOfWorkExecute>();
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
            app.UseCors("any");
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseFileServer(new FileServerOptions()
             {
               FileProvider = new PhysicalFileProvider
               (
                     Path.Combine(Directory.GetCurrentDirectory(), @"images")),   //ʵ��Ŀ¼��ַ
                     RequestPath = new Microsoft.AspNetCore.Http.PathString("/images"),  //�û����ʵ�ַ
                     EnableDirectoryBrowsing = true                                     //����Ŀ¼���
               });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
