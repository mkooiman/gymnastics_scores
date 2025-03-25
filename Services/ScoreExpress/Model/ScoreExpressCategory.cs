namespace GymnasticScores.Services.ScoreExpress.Model;



public record ScoreExpressCategory(
    string Id = null!,
    string Title = null!,
    string Status = null!,
    List<ScoreExpressRound> Rounds = null!)
{
    public ScoreExpressCategory() : this(
        Id: null!,
        Title: null!,
        Status: null!,
        Rounds: new List<ScoreExpressRound>())
    { }
}