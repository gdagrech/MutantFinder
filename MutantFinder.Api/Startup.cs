using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MutantFinder.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Mutant Finder",
                    Description = "Mutant Finder API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Gabriel D. Agrech",
                        Email = "gagrech@gmail.com.ar"
                    },
                    License = new License
                    {
                        Name = "Acuerdo de Confidencialidad"
                    }
                });

                //var filePath = Path.Combine(AppContext.BaseDirectory, @"../../MutantFinder.Api.xml");
                //c.IncludeXmlComments(filePath);

            });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MutantFinder V1");
            });
            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
