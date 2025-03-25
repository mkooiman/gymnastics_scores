namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexRanking(
    string Id = null!,
    Dictionary<string,string> Title = null!,
    int Round = 0,
    string Type = null!,
    string Subtype = null!,
    string ExerciseType = null);