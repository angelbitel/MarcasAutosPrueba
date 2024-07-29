using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Brands.Queries.GetCarBrands
{
    internal class GetCarBrandsQueryHandler : IQueryHandler<GetCarBrandsQuery, List<Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetCarBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Result<List<Brand>>> Handle(GetCarBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _brandRepository.GetBrandsAsync(request.type);
        }
    }
}
