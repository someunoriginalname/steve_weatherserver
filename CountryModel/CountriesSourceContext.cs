using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CountryModel;

public partial class CountriesSourceContext : DbContext
{
    public CountriesSourceContext()
    {
    }

    public CountriesSourceContext(DbContextOptions<CountriesSourceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB;Initial Catalog=CountriesGolden;Integrated Security=True; Connect Timeout=30; Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Table__F2D21A965FAEB50E");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D160BFC940CCB6");

            entity.Property(e => e.CountryId).ValueGeneratedNever();
            entity.Property(e => e.Iso2).IsFixedLength();
            entity.Property(e => e.Iso3).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
