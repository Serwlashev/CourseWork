using Catalog.API.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Services.Catalog.Core.Application.Mapping;
using Services.Catalog.Infrastructure.Persistence;
using Services.Catalog.Infrastructure.Services;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateCategory;
using Services.Catalog.Presentation.Catalog.API.Filters;
using System;
using System.Reflection;

namespace Catalog.API
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

            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Caching",
                        new CacheProfile()
                        {
                            Duration = 300,
                            NoStore = false
                        }); ;
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(cnfg =>
            {
                cnfg.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
            })
                .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);

            services.AddResponseCaching();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
            });

            #region Mapping configuration

            services.AddAutoMapper(cfg =>
            {
                cfg.DisableConstructorMapping();
            }, typeof(ModelMappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion

            #region Services configuration

            services.AddPersistenceServices();
            services.AddInfrastructureServices();

            #endregion

            #region Database configuration

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            #endregion

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandleMiddleware>();

            app.Use(async (ctx, next) =>
            {
                ctx.Request.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(120)
                };
                await next();
            });
            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
