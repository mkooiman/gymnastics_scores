using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GymnasticScores.Logic.Model;

namespace GymnasticScores.Data.Entities;
public class EventEntity
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Group { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Venue { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public string LogoUrl { get; set; }

    // Navigation property for the one-to-many relationship
    public List<DisciplineEntity> Disciplines { get; set; } = new ();
}

