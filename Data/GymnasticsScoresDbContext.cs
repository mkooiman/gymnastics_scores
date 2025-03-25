using GymnasticScores.Data.Entities;
using GymnasticScores.Logic.Model;
using Microsoft.EntityFrameworkCore;

namespace GymnasticScores.Data;

public class GymnasticsScoresDbContext : DbContext
{
    public GymnasticsScoresDbContext(DbContextOptions<GymnasticsScoresDbContext> options) : base(options) {}

    public DbSet<OrganizationEntity> Organizations { get; set; }
    
    public DbSet<EventEntity> Events { get; set; }
    
    public DbSet<DisciplineEntity> Disciplines { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the one-to-many relationship
        modelBuilder.Entity<EventEntity>()
            .HasMany(e => e.Disciplines)
            .WithOne(d => d.Event)
            .HasForeignKey(d => d.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure string properties with max length (optional but recommended)
        modelBuilder.Entity<EventEntity>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Group).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Venue).HasMaxLength(200);
            entity.Property(e => e.LogoUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<DisciplineEntity>(entity =>
        {
            entity.Property(d => d.Id).HasMaxLength(50);
            entity.Property(d => d.Group).HasMaxLength(100);
            entity.Property(d => d.Title).HasMaxLength(200);
            entity.Property(d => d.LogoUrl).HasMaxLength(500);
        });
    }
}