using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Domain.Entities;
using ECommerceBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
