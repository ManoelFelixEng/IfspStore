

using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Date);
            builder.Property(prop => prop.TotalAmount);
            builder.HasOne(prop => prop.Customer);
            builder.HasOne(prop => prop.Salesman);
            builder.HasMany(prop => prop.SaleItens).WithOne(prop => prop.Sale).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class SaleItemMap : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItem");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Quatity);
            builder.Property(prop => prop.UnitPrice);
            builder.Property(prop => prop.TotalPrice);
            builder.HasOne(prop => prop.Sale).WithMany(prop => prop.SaleItens).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(prop => prop.Product);
        }
    }
}
