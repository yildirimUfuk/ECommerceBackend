﻿using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<ECommerceDbContext>(Options => Options.UseNpgsql(Configuration.postgreSQLConnection));
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
        }
    }
}
