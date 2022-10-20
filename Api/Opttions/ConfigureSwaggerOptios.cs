using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Opttions
{
    public class ConfigureSwaggerOptios : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider Provider;
        public ConfigureSwaggerOptios(IApiVersionDescriptionProvider provider)
        {
            Provider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var item in Provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(item.GroupName, CreateVersionInfo(item));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription item)
        {
            var info = new OpenApiInfo()
            {
                Title = "Bicode Api David Stiven Bedoya Salazar",
                Version = item.ApiVersion.ToString()
            };
            return info;
        }
    }
}
