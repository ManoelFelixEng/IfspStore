

using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(100);
            builder.Property(prop => prop.Password).IsRequired().HasMaxLength(45);
            builder.Property(prop => prop.Login).IsRequired().HasMaxLength(45);
            builder.Property(prop => prop.Email).IsRequired().HasMaxLength(100);
            builder.Property(prop => prop.RegistrationDate).HasDefaultValue(DateTime.Now);
            builder.Property(prop => prop.LoginDate);
            builder.Property(prop => prop.Active);
        }
    }
}
