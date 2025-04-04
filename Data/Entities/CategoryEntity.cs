namespace GymnasticScores.Data.Entities;

public class CategoryEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
    public DateTime Added { get; set; }
    public List<RoundEntity> Rounds { get; set; }
}
