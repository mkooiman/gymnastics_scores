namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressParticipation(
    int Number = 0,
    string Category = null!,
    List<string> Names = null!,
    string Club = null!,
    string Country = null!,
    List<ScoreExpressScoreRound> Scores = null!,
    object? AaResults = null) // Using object? since it's null in the JSON, but could be structured if data exists
{
    public ScoreExpressParticipation() : this(
        Number: 0,
        Category: null!,
        Names: new List<string>(),
        Club: null!,
        Country: null!,
        Scores: new List<ScoreExpressScoreRound>(),
        AaResults: null)
    { }
}