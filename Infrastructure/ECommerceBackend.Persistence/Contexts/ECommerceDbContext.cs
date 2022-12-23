using ECommerceBackend.Domain.Entities;
using ECommerceBackend.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: It catch updated or inserted data which follow by tracking mechanism
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    //if state is 'added'
                    EntityState.Added => data.Entity.CreationDate = DateTime.UtcNow,
                    //if state is 'modified'
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    //if state is none of these (this structure enters the last statement if all statement before the last one are false.)
                    _=>DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
