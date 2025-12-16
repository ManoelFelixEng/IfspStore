using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(100);
            builder.Property(prop => prop.Price);
            builder.Property(prop => prop.Quantity);
            builder.Property(prop => prop.DateShop);
            builder.Property(prop => prop.SalesUnit).IsRequired().HasMaxLength(10);
            builder.HasOne(prop => prop.Category);
        }
    }
}
