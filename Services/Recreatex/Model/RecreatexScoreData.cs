namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexScoreData(
    string Id = null!,
    string Group = null!,
    string Type = null!,
    string Subtype = null!,
    string? TeamMethod = null, // Nullable since it's null in the JSON
    Dictionary<string,string> Title = null!,
    int Round = 0,
    List<RecreatexExerciseGroup> Exercises = null!,
    List<RecreatexItem> Items = null!)
{
    public RecreatexScoreData() : this(
        Id: null!,
        Group: null!,
        Type: null!,
        Subtype: null!,
        TeamMethod: null,
        Title: null!,
        Round: 0,
        Exercises: new List<RecreatexExerciseGroup>(),
        Items: new List<RecreatexItem>())
    { }
}