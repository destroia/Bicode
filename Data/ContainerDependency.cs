using Data.Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ContainerDependency
    {
        public static IServiceCollection AddDependencyData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BI_TESTGENContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionMain")));

            services.AddScoped<IGenero, GeneroData>();
            services.AddScoped<IDocumento, DocumentoData>();
            services.AddScoped<IPersona, PersonaData>();

            return services;
        }
    }
}
