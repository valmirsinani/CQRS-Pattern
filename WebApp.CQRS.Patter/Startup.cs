using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using System.Reflection;
using System.Threading.Tasks;
using WebApp.CQRS.Data;
using MediatR;
using WebApp.CQRS.Patter.Contracts.CommandHandlers;
using WebApp.CQRS.Patter.Handlers.CommandsHandlers;

namespace WebApp.CQRS.Patter
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp.CQRS.Patter", Version = "v1" });
            });

            services.AddDbContext<MyAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyAppDbConnection"), b => b.MigrationsAssembly("WebApp.CQRS.Patter"));
             
            });

           // services.AddScoped<ISaveProductCommandHandler, SaveProductCommandHandler>();
            //services.AddScoped<IAllProductsQueryHandler,AllProductsQueryHandler>();
            //services.AddScoped<IPriceRangeProductsQueryHandler, PriceRangeProductsQueryHandler>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           // if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp.CQRS.Patter v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
