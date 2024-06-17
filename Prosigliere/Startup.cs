using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prosigliere.Data;
using Prosigliere.Repositories;

namespace Prosigliere
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureDbContext(services);
            InjectDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        protected virtual void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<IDatabaseSource, DatabaseSource>((context, opt) =>
            {
                var configuration = context.GetRequiredService<IConfiguration>();
                opt.UseSqlServer(configuration.GetConnectionString(""));
        });
        }

        protected void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<IBlogRepository, BlogRepository>();
        }
    }

}
