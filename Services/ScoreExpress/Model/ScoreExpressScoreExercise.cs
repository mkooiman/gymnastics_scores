namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressScoreExercise(
    string? Total = null, // Nullable since some are missing
    List<ScoreExpressPass> Passes = null!,
    string? RoundId = null, // Nullable since missing in some cases
    string? ExerciseTypeId = null, // Nullable since "exercise" is used in some cases
    string? Exercise = null, // Nullable since used instead of ExerciseTypeId in some cases
    string Status = null!)
{
    public ScoreExpressScoreExercise() : this(
        Total: null,
        Passes: new List<ScoreExpressPass>(),
        RoundId: null,
        ExerciseTypeId: null,
        Exercise: null,
        Status: null!)
    { }
}