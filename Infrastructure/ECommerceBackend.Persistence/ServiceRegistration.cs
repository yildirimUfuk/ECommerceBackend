using Microsoft.EntityFrameworkCore;
using ECommerceBackend.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices (this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(Options => Options.UseNpgsql(Configuration.postgreSQLConnection));
        }
    }
}
