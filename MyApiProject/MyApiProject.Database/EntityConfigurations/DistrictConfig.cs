using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApiProject.DomainLayer;
using MyApiProject.DomainLayer.Shared;

namespace MyApiProject.Database.EntityConfigurations;

public class DistrictConfig : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=> x.Name).IsRequired().HasMaxLength(256);
        builder.HasOne(x => x.City).WithMany(x=>x.Districts).HasForeignKey(x=>x.CityId).OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        builder.Property(x => x.Status).HasDefaultValue(DataStatus.Active);
    }
}
