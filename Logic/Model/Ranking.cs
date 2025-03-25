namespace GymnasticScores.Logic.Model;

public record Ranking(
    string Id = null!,
    Dictionary<string,string> Title = null!,
    int Round = 0,
    string Type = null!,
    string Subtype = null!,
    string ExerciseType = null);