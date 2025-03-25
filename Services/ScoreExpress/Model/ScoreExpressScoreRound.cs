namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressScoreRound(
    int Round = 0,
    List<ScoreExpressScoreExercise> Exercises = null!)
{
    public ScoreExpressScoreRound() : this(
        Round: 0,
        Exercises: new List<ScoreExpressScoreExercise>())
    { }
}