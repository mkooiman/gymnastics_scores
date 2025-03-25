namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexParticipation(
    int Number = 0,
    string Category = null!,
    List<string> Names = null!,
    string Club = null!,
    string Country = null!,
    List<RecreatexScoreRound> Scores = null!,
    object? AaResults = null) // Using object? since it's null in the JSON, but could be structured if data exists
{
    public RecreatexParticipation() : this(
        Number: 0,
        Category: null!,
        Names: new List<string>(),
        Club: null!,
        Country: null!,
        Scores: new List<RecreatexScoreRound>(),
        AaResults: null)
    { }
}