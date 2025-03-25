namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexScoreExercise(
    string? Total = null, // Nullable since some are missing
    List<RecreatexPass> Passes = null!,
    string? RoundId = null, // Nullable since missing in some cases
    string? ExerciseTypeId = null, // Nullable since "exercise" is used in some cases
    string? Exercise = null, // Nullable since used instead of ExerciseTypeId in some cases
    string Status = null!)
{
    public RecreatexScoreExercise() : this(
        Total: null,
        Passes: new List<RecreatexPass>(),
        RoundId: null,
        ExerciseTypeId: null,
        Exercise: null,
        Status: null!)
    { }
}