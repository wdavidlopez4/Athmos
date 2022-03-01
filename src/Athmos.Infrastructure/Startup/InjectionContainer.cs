using Athmos.Domain.Entities;
using Athmos.Domain.Ports;
using Athmos.Infrastructure.MappObject;
using Athmos.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Infrastructure.Startup
{
    public class InjectionContainer
    {
        public static void Inyection(IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, AthmosRepositorySQL<User>>();
            services.AddScoped<IMapObject, MapObject>();
        }
    }
}
