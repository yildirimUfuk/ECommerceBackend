using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Domain.Entities.Common;
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
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDbContext _context;

        public ReadRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            // just queriable objects can change own tracking meshanism
            var query = Table.AsQueryable();
            //if it doesn'tneed to be track, tracking mechanism is turned off by 'AsNoTracking()'
            if(!tracking) 
                query=query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            // just queriable objects can change own tracking meshanism
            var query = Table.Where(method).AsQueryable();
            //if it doesn'tneed to be track, tracking mechanism is turned off by 'AsNoTracking()'
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            // just queriable objects can change own tracking meshanism
            var query = Table.AsQueryable();
            //if it doesn'tneed to be track, tracking mechanism is turned off by 'AsNoTracking()'
            if (!tracking)
                query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsnc(string id, bool tracking = true)
        //=>  await Table.FirstOrDefaultAsync(data=>data.id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            // just queriable objects can change own tracking meshanism
            var query = Table.AsQueryable();
            //if it doesn'tneed to be track, tracking mechanism is turned off by 'AsNoTracking()'
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.id == Guid.Parse(id)); 
        }
    }
}
