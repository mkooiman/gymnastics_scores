using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GymnasticScores.Logic.Model;

namespace GymnasticScores.Data.Entities;

public class DisciplineEntity
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Group { get; set; }

    [Required]
    public string Title { get; set; }

    public ExerciseCode Exercise { get; set; }

    public string LogoUrl { get; set; }

    public bool ShowFlags { get; set; }

    // Foreign key for Event
    public string EventId { get; set; }

    // Navigation property back to Event
    [ForeignKey("EventId")]
    public EventEntity Event { get; set; }
}