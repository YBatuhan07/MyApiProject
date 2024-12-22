using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApiProject.DomainLayer;
using MyApiProject.DomainLayer.Shared;

namespace MyApiProject.Database.EntityConfigurations;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        builder.Property(x=>x.Status).HasDefaultValue(DataStatus.Active);
    }
}
