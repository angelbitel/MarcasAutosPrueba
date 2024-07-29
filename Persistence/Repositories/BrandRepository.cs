using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BrandRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Brand>> GetBrandsAsync(BrandType type,CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Brand>()
                .Where(w=> w.Type == type)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Brand>> GetBrandsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Brand>()
                .Where(w => (w.Name??"").ToLower() == name.ToLower())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
