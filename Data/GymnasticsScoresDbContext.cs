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
    
    public DbSet<ParticipationEntity> Participations { get; set; }
    
    public DbSet<ScoreRoundEntity> ScoreRounds { get; set; }
    
    public DbSet<ScoreExerciseEntity> ScoreExercises { get; set; }
    
    public DbSet<ParticipantNameEntity> ParticipantNames { get; set; }
    
    public DbSet<AllAroundResultEntity> AllAroundResults { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
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

        modelBuilder.Entity<ParticipationEntity>(entity =>
        {
            entity.Property(p => p.Id).HasMaxLength(50);
            entity.Property(p => p.Category).HasMaxLength(100);
            entity.Property(p => p.Club).HasMaxLength(200);
            entity.Property(p => p.Country).HasMaxLength(100);
            entity.Property(p => p.Names).HasMaxLength(1000);
            entity.Property(p => p.Scores).HasMaxLength(4000);
            entity.Property(p => p.AaResults).HasMaxLength(2000);
        });

        modelBuilder.Entity<ScoreRoundEntity>(entity =>
        {
            entity.HasOne(s => s.Participation)
                .WithMany(p => p.ScoreRounds)
                .HasForeignKey(s => s.ParticipationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ScoreExerciseEntity>(entity =>
        {
            entity.Property(e => e.ExerciseCode).HasMaxLength(50);
            entity.HasOne(s => s.ScoreRound)
                .WithMany(r => r.Exercises)
                .HasForeignKey(s => s.ScoreRoundId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ParticipantNameEntity>(entity =>
        {
            entity.Property(n => n.Name).HasMaxLength(200);
            entity.HasOne(n => n.Participation)
                .WithMany(p => p.Names)
                .HasForeignKey(n => n.ParticipationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<AllAroundResultEntity>(entity =>
        {
            entity.Property(a => a.Discipline).HasMaxLength(100);
            entity.HasOne(a => a.Participation)
                .WithMany(p => p.AllAroundResults)
                .HasForeignKey(a => a.ParticipationId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}