using EFCore7JsonDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore7JsonDemo.Data;

public class PersonJsonMap : IEntityTypeConfiguration<PersonJsonDbEntity> {
    public void Configure(EntityTypeBuilder<PersonJsonDbEntity> builder) {
        builder.ToTable("PersonJson", "dbo");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.OwnsOne(p => p.Person, pb => {
            pb.ToJson();

            pb.OwnsOne(p => p.Education);

            //pb.OwnsMany(p => p.Addresses);
        });
    }
}
