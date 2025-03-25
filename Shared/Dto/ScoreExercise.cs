namespace Shared.Dto;

public record ScoreExerciseDto(
    string? Total = null, 
    List<PassDto> Passes = null!,
    string? RoundId = null, 
    string? ExerciseTypeId = null,
    string? Exercise = null,
    string Status = null!)
{
    public ScoreExerciseDto() : this(
        Total: null,
        Passes: new List<PassDto>(),
        RoundId: null,
        ExerciseTypeId: null,
        Exercise: null,
        Status: null!)
    { }
}