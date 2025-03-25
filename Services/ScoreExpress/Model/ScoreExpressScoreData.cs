namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressScoreData(
    string Id = null!,
    string Group = null!,
    string Type = null!,
    string Subtype = null!,
    string? TeamMethod = null, // Nullable since it's null in the JSON
    Dictionary<string,string> Title = null!,
    int Round = 0,
    List<ScoreExpressExerciseGroup> Exercises = null!,
    List<ScoreExpressItem> Items = null!)
{
    public ScoreExpressScoreData() : this(
        Id: null!,
        Group: null!,
        Type: null!,
        Subtype: null!,
        TeamMethod: null,
        Title: null!,
        Round: 0,
        Exercises: new List<ScoreExpressExerciseGroup>(),
        Items: new List<ScoreExpressItem>())
    { }
}