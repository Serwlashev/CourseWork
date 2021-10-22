using Microsoft.EntityFrameworkCore;
using Services.Catalog.Core.Domain.Entity;
using Services.Catalog.Core.Domain.Interfaces.Repository;
using Services.ServicesShared.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Persistence.Implementation.Repositories
{
    public class ProductsRepository : BaseRepository<long, Product>, IProductsRepository<long, Product>
    {
        public ProductsRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> FindAsync(string searchText, CancellationToken token = default)
        {
            IEnumerable<Product> entities = null;

            if (string.IsNullOrEmpty(searchText))
            {
                entities = await _context.Products
                    .Include(p => p.Category)
                    .ToListAsync(token)
                    .ConfigureAwait(false);
            }
            else
            {
                entities = await _context.Products
                    .Include(p => p.Category)
                    .Where(product
                        => product.Name.ToLower().Equals(searchText.ToLower())
                            || product.Category.Name.ToLower().Equals(searchText.ToLower()))
                    .ToListAsync(token)
                    .ConfigureAwait(false);
            }

            if (!entities.Any())
            {
                throw new NotFoundException("Not found");
            }

            return entities;
        }

        public override async Task<IEnumerable<Product>> GetAllAsync(CancellationToken token = default)
        {
            var entities = await _context.Products.Include(p => p.Category).ToListAsync(token).ConfigureAwait(false);

            if (!entities.Any())
            {
                throw new NotFoundException("Not found");
            }

            return entities;
        }

        public override async Task<Product> GetAsync(long id, CancellationToken token = default)
        {
            var entity = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id, token).ConfigureAwait(false);

            if (entity is null)
            {
                throw new NotFoundException("Entity not found");
            }

            return entity;
        }
    }
}
