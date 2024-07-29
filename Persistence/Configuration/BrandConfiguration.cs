using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    internal sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");

            builder.HasKey(brand => brand.Id);

            builder.HasIndex(brand => brand.Id).IsUnique();

            builder.Property(brand => brand.Name).IsRequired();
            builder.Property(brand => brand.Type).IsRequired();
        }
    }
}
