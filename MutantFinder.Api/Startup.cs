using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MutantFinder.Api.Models;
using MutantFinder.DataLayer.Abstract;
using MutantFinder.DataLayer.Concrete;
using MutantFinder.Domain.Entities;
using MutantFinder.Services.Abstract;
using MutantFinder.Services.DataServices;
using Swashbuckle.AspNetCore.Swagger;

namespace MutantFinder.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
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
                        Email = "gdagrech@gmail.com.ar"
                    },
                });

            });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            var conn = Startup.Configuration["connectionsStrings:dnaSequencesDBConnectionString"];
            services.AddDbContext<MutantFinderContext>(o => o.UseSqlServer(conn));
            services.AddScoped<IDnaSequenceRepository, DnaSequenceRepository>();
            services.AddScoped<IDnaSequenceService, DnaSequenceService>();
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
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DnaSequence, DnaSequenceDto>();
                cfg.CreateMap<DnaSequenceDto, DnaSequence>().ForMember(x => x.IsMutant, opt => opt.Ignore());
                cfg.CreateMap<DnaSequenceForCreationDto, DnaSequence>();
            });
            app.UseMvc();
        }
    }
}
