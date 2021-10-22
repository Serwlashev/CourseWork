using Microsoft.EntityFrameworkCore;
using Services.Catalog.Core.Domain.Entity;
using Services.Catalog.Core.Domain.Interfaces.Repository;
using Services.ServicesShared.Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Persistence.Implementation.Repositories
{
    public class CategoriesRepository : BaseRepository<long, Category>, ICategoriesRepository<long, Category>
    {
        public CategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task RemoveAsync(Category entity, CancellationToken token = default)
        {
            if (await _context.Products.AnyAsync(product => entity != null && product.Id == entity.Id, token).ConfigureAwait(false))
            {
                throw new ForbiddenActionException("Unable to delete category due to existing relationship with products!");
            }

            await base.RemoveAsync(entity, token);
        }
    }
}
