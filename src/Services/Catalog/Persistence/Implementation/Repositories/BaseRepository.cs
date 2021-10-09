using Microsoft.EntityFrameworkCore;
using Services.ServicesShared.Core.Exceptions;
using Services.ServicesShared.Core.Interfaces.Repository;
using Services.ServicesShared.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual async Task<IEnumerable<TValue>> GetAllAsync()
        {
            var entities = await Table.ToListAsync();

            if (!entities.Any())
            {
                throw new NotFoundException("Not found");
            }

            return entities;
        }

        public virtual async Task<TValue> GetAsync(TKey id)
        {
            var entity = await Table.FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Entity not found");
            }

            return entity;
        }

        public void Create(TValue entity)
            => Table.Add(entity);

        public virtual void Remove(TValue entity)
        {
            if (!Table.Contains(entity))
            {
                throw new NotFoundException("Cannot remove entity because it does not exist");
            }

            Table.Remove(entity);
        }

        public void Update(TValue entity)
        {
            if (!Table.Contains(entity))
            {
                throw new NotFoundException("Cannot update entity because it does not exist");
            }

            Table.Update(entity);
        }
    }
}
