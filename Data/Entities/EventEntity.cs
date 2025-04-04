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
    
    public string? Venue { get; set; }

    public DateTime Added { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public string? LogoUrl { get; set; }
    

    [ForeignKey("OrganizationId")]
    public OrganizationEntity Organization { get; set; }

    public List<DisciplineEntity> Disciplines { get; set; }
}


