namespace Shared.Dto;

public record RankingDto(
    string Id = null!,
    Dictionary<string,string> Title = null!,
    int Round = 0,
    string Type = null!,
    string Subtype = null!,
    string ExerciseType = null);