using System.ComponentModel.DataAnnotations.Schema;
using GymnasticScores.Logic.Model;

namespace GymnasticScores.Data.Entities;

public class RoundEntity
{
    public int Index { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
}