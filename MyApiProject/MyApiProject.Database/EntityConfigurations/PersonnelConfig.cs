using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApiProject.DomainLayer;

namespace MyApiProject.Database.EntityConfigurations;

public class PersonnelConfig : IEntityTypeConfiguration<Personnel>
{
    public void Configure(EntityTypeBuilder<Personnel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Gender).IsRequired().HasMaxLength(10);
        builder.HasOne(x => x.District).WithMany(x => x.Personnels).HasForeignKey(x=>x.DistrictId).IsRequired().OnDelete(deleteBehavior: DeleteBehavior.NoAction);
    }
}
