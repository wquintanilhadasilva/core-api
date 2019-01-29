using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace core_api
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
            services.AddMvc();

            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Laboratório de API Asp.Net Core",
                        Version = "v1",
                        Description = "Exemplo de Asp.Net Core Web API",
                        Contact = new Contact
                        {
                            Name = "Wedson Quintanilha da Silva",
                            Email = "wquintanilhadasilva@gmail.com",
                            Url = "https://github.com/wquintanilhadasilva/"
                        }
                    });

                var appPath = PlatformServices.Default.Application.ApplicationBasePath;
                var appName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocPath = Path.Combine(appPath, $"{appName}.xml");
                c.IncludeXmlComments(xmlDocPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab de swagger e .net Core Api");
            });
        }
    }
}
