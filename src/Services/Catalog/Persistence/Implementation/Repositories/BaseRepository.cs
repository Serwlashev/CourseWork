using Microsoft.EntityFrameworkCore;
using Services.ServicesShared.Core.Exceptions;
using Services.ServicesShared.Core.Interfaces.Repository;
using Services.ServicesShared.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Persistence.Implementation.Repositories
{
    public abstract class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<TValue> Table => _context.Set<TValue>();

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TValue>> GetAllAsync(CancellationToken token = default)
        {
            var entities = await Table.ToListAsync(token).ConfigureAwait(false);

            if (!entities.Any())
            {
                throw new NotFoundException("Not found");
            }

            return entities;
        }

        public virtual async Task<TValue> GetAsync(TKey id, CancellationToken token = default)
        {
            var entity = await Table.FindAsync(id, token).ConfigureAwait(false);

            if (entity == null)
            {
                throw new NotFoundException("Entity not found");
            }

            return entity;
        }

        public async Task CreateAsync(TValue entity, CancellationToken token = default)
            => await Table.AddAsync(entity, token).ConfigureAwait(false);

        public virtual async Task RemoveAsync(TValue entity, CancellationToken token = default)
        {
            if (!(await Table.ContainsAsync(entity, token).ConfigureAwait(false)))
            {
                throw new NotFoundException("Cannot remove entity because it does not exist");
            }

            Table.Remove(entity);
        }

        public async Task UpdateAsync(TValue entity, CancellationToken token = default)
        {
            if (!(await Table.ContainsAsync(entity, token).ConfigureAwait(false)))
            {
                throw new NotFoundException("Cannot update entity because it does not exist");
            }

            Table.Update(entity);
        }
    }
}
