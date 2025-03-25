namespace GymnasticScores.Services.Recreatex.Model;



public record RecreatexCategory(
    string Id = null!,
    string Title = null!,
    string Status = null!,
    List<RecreatexRound> Rounds = null!)
{
    public RecreatexCategory() : this(
        Id: null!,
        Title: null!,
        Status: null!,
        Rounds: new List<RecreatexRound>())
    { }
}