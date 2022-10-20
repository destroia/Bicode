using Api.Opttions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
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
            services.AddSwaggerGen();// c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            // //   c.SwaggerDoc("v2", new OpenApiInfo { Title = "Api", Version = "V2" });
            //});
            
            services.ConfigureOptions<ConfigureSwaggerOptios>();
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                //opt.DefaultApiVersion = new ApiVersion(2, 0);
                //opt.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;

            });
            //Implementacion de AutoMapper
            var mapperConfug = new MapperConfiguration(x => {
                x.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfug.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvcCore();

            services.AddDependencyBicode(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
            }
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var item in provider.ApiVersionDescriptions)
                {
                    opt.SwaggerEndpoint("/swagger/" + item.GroupName + "/swagger.json", item.ApiVersion.ToString());
                }
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
