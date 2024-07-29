using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Brands.Queries.GetCarBrandsByName
{
    internal class GetCarBrandsByNameQueryHandler : IQueryHandler<GetCarBrandsByNameQuery, List<Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetCarBrandsByNameQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Result<List<Brand>>> Handle(GetCarBrandsByNameQuery request, CancellationToken cancellationToken)
        {
            return await _brandRepository.GetBrandsByNameAsync(request.name);
        }
    }
}
