namespace GymnasticScores.Data.Entities;

public class OrganizationEntity
{

    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? Locale { get; set; }
    public string? LogoUrl { get; set; } 
    public DateTime Added { get; set; }
    
    
    public List<EventEntity> Events { get; set; } = new ();
}