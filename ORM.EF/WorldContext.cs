using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

using ORM.EF.Models;

namespace ORM.EF
{
    public partial class WorldContext : DbContext
    {
        public WorldContext()
        {
        }

        public WorldContext(DbContextOptions<WorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Countrylanguage> Countrylanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning 指令
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("data source=127.0.0.1;port=3306;initial catalog=world;user id=test;password=test@123;pooling=false;charset=utf8", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.19-mysql"));
#pragma warning restore CS1030 // #warning 指令
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.CountryCode, "CountryCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasColumnType("char(20)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_ibfk_1");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("country");

                entity.Property(e => e.Code)
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Code2)
                    .IsRequired()
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Continent)
                    .IsRequired()
                    .HasColumnType("enum('Asia','Europe','North America','Africa','Oceania','Antarctica','South America')")
                    .HasDefaultValueSql("'Asia'")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Gnp)
                    .HasColumnType("float(10,2)")
                    .HasColumnName("GNP");

                entity.Property(e => e.Gnpold)
                    .HasColumnType("float(10,2)")
                    .HasColumnName("GNPOld");

                entity.Property(e => e.GovernmentForm)
                    .IsRequired()
                    .HasColumnType("char(45)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.HeadOfState)
                    .HasColumnType("char(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LifeExpectancy).HasColumnType("float(3,1)");

                entity.Property(e => e.LocalName)
                    .IsRequired()
                    .HasColumnType("char(45)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(52)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnType("char(26)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SurfaceArea).HasColumnType("float(10,2)");
            });

            modelBuilder.Entity<Countrylanguage>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.Language })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("countrylanguage");

                entity.HasIndex(e => e.CountryCode, "CountryCode");

                entity.Property(e => e.CountryCode)
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Language)
                    .HasColumnType("char(30)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IsOfficial)
                    .IsRequired()
                    .HasColumnType("enum('T','F')")
                    .HasDefaultValueSql("'F'")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Percentage).HasColumnType("float(4,1)");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Countrylanguages)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("countryLanguage_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
