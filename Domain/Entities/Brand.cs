using Domain.Enum;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Brand: AggregateRoot
    {
        public BrandType Type { get; set; }
        public string? Name { get; set; }
    }
}
