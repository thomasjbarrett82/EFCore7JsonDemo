using EFCore7JsonDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore7JsonDemo.Data;

public class SqlDbContext : DbContext {
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

    public DbSet<PersonJsonDbEntity> PeopleJson { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new PersonJsonMap());
        modelBuilder.ApplyConfiguration(new PersonMap());

        base.OnModelCreating(modelBuilder);
    }
}
