namespace GymnasticScores.Logic.Model;

public record Participation(
    int Number,
    string Category, 
    List<string> Names,
    string Club,
    string Country,
    List<ScoreRound> Scores,
    object? AaResults) 
{
    
    public Participation() : this(
        Number: 0,
        Category: null!,
        Names: new List<string>(),
        Club: null!,
        Country: null!,
        Scores: new List<ScoreRound>(),
        AaResults: null)
    { }
}