using DAL.Configs;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework;

#nullable disable

public class DatabaseContext : DbContext
{
    public DatabaseContext() { }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public virtual DbSet<Cook> Cooks { get; set; }
    public virtual DbSet<Pizza> Pizzas { get; set; }
    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(Config.DbConfig());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.ToTable("Pizza");
            entity.HasIndex(e => e.Id, "Id");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasColumnType("CHAR");
            entity.Property(e => e.Caloric).HasColumnType("INT");
        });
        
        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.ToTable("Restaurant");
            entity.HasIndex(e => e.Id, "Id");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasColumnType("CHAR");
            entity.Property(e => e.Revenue).HasColumnType("INT");
        });
        
        modelBuilder.Entity<Cook>(entity =>
        {
            entity.ToTable("Cook");
            entity.HasIndex(e => e.Id, "Id");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasColumnType("CHAR");
            entity.Property(e => e.Age).HasColumnType("INT");
            entity.Property(e => e.PizzaId).HasColumnType("INT");
            entity.Property(e => e.RestaurantId).HasColumnType("INT");
            entity.HasOne(c => c.Pizza)
                .WithMany(p => p.Cooks)
                .HasForeignKey(cook => cook.PizzaId);
            entity.HasOne(s => s.Restaurant)
                .WithMany(r => r.Cooks)
                .HasForeignKey(cook => cook.RestaurantId);
        });
    }
}