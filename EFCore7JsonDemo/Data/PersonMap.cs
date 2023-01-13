using EFCore7JsonDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore7JsonDemo.Data;

public class PersonMap : IEntityTypeConfiguration<Person> {
    public void Configure(EntityTypeBuilder<Person> builder) {
        builder.ToTable("Person", "dbo");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.OwnsOne(p => p.Education, pb => {
            pb.ToTable("Education", "dbo");
            pb.HasKey(c => c.Id);
            pb.Property(c => c.Id).ValueGeneratedOnAdd();
        });

        builder.OwnsMany(p => p.Addresses, ab => {
            ab.ToTable("Address", "dbo");
            ab.HasKey(c => c.Id);
            ab.Property(c => c.Id).ValueGeneratedOnAdd();
        });
    }
}
