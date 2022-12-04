using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Domain.Entities;
using ECommerceBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
