namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexScoreRound(
    int Round = 0,
    List<RecreatexScoreExercise> Exercises = null!)
{
    public RecreatexScoreRound() : this(
        Round: 0,
        Exercises: new List<RecreatexScoreExercise>())
    { }
}