using Domain.Entities;
using Domain.Enum;

namespace Domain.Repositories
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetBrandsAsync(BrandType Type,CancellationToken cancellationToken = default);
        Task<List<Brand>> GetBrandsByNameAsync(string name,CancellationToken cancellationToken = default);
    }
}
