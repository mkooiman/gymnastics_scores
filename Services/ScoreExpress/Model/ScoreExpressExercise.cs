namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressExercise(
    string ExerciseTypeId = null!,
    int Round = 0,
    int Passes = 0);