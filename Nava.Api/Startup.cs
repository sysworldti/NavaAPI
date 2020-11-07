using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Nava.Api.Repository;
using Nava.Api.Service;
using System;
using System.IO;

namespace Nava.Api
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        private const string POLICY_NAVA = "NAVA_CORS";

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors(options =>
            {
                options.AddPolicy(POLICY_NAVA, policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Nava API",
                    Version = "Versão 1.0",
                    Description = "Nava API",
                    Contact = new OpenApiContact
                    {
                        Name = "Nava.API",
                        Url = new Uri("https://nava.com.br/pt/"),
                        Email = "nava@nava.com.br"
                    }
                });

                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml"));
            });

            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("NavaDB"));
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IVendaService, VendaService>();
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(
#if DEBUG
                    "/swagger/v1/swagger.json"
#else
                    "/webapi/swagger/v1/swagger.json"
#endif
                , "Nava.API"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(POLICY_NAVA);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
