namespace GymnasticScores.Logic.Model;

public record ScoreExercise(
    string? Total = null, // Nullable since some are missing
    List<Pass> Passes = null!,
    string? RoundId = null, // Nullable since missing in some cases
    string? ExerciseTypeId = null, // Nullable since "exercise" is used in some cases
    string? Exercise = null, // Nullable since used instead of ExerciseTypeId in some cases
    string Status = null!)
{
    public ScoreExercise() : this(
        Total: null,
        Passes: new List<Pass>(),
        RoundId: null,
        ExerciseTypeId: null,
        Exercise: null,
        Status: null!)
    { }
}