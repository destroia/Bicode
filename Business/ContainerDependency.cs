using Business.Business;
using Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ContainerDependency
    {
        public static IServiceCollection AddDependencyBusiness(this IServiceCollection services)
        {
           
            services.AddScoped<IGenero, GeneroBI>();
            services.AddScoped<IDocumento, DocumentoBI>();
            services.AddScoped<IPersona, PersonaBI>();

            return services;
        }
    }
}
