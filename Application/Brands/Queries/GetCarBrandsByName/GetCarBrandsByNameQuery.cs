using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Brands.Queries.GetCarBrandsByName
{
    public sealed record GetCarBrandsByNameQuery(string name) : IQuery<List<Brand>>;
}
