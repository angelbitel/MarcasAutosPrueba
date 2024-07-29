using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Enum;

namespace Application.Brands.Queries.GetCarBrands
{
    public sealed record GetCarBrandsQuery(BrandType type) : IQuery<List<Brand>>;
}
