namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexExercise(
    string ExerciseTypeId = null!,
    int Round = 0,
    int Passes = 0);