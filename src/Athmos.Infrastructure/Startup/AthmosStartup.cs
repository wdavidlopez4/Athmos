using Athmos.Application.UserServices.GetAllUsers;
using Athmos.Application.UserServices.RegisterUser;
using Athmos.Application.UserServices.UpdateUser;
using Athmos.Infrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Infrastructure.Startup
{
    public class AthmosStartup
    {
        public static void SetUp(IServiceCollection services, IConfiguration configuration)
        {
            InjectionContainer.Inyection(services);
            ConfigurationSqlServer(services, configuration);
            ConfigurarMapper(services);
            ConfigurarMediador(services);
        }

        /// <summary>
        /// configura el sql server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigurationSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            // entity framework db context
            string connString = configuration.GetConnectionString("EpikConnectionString");
            services.AddDbContext<AthmosContext>(
                options => options.UseSqlServer(connString));
        }

        /// <summary>
        /// configura el mapeo del sistema dto-entitdades de modelo
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// configura el patron mediator controladores- servicios
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(RegisterUserCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllUsersQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateUserCommand).GetTypeInfo().Assembly);
        }
    }
}
