namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressExerciseGroup(
    int Round = 0,
    bool AddTotal = false,
    List<ScoreExpressExercise> Exercises = null!)
{
    public ScoreExpressExerciseGroup() : this(
        Round: 0,
        AddTotal: false,
        Exercises: new List<ScoreExpressExercise>())
    { }
}