using Microsoft.EntityFrameworkCore;
using ECommerceBackend.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Persistence.Repositories;

namespace ECommerceBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices (this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(Options => Options.UseNpgsql(Configuration.postgreSQLConnection),ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository,OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();
        }
    }
}
