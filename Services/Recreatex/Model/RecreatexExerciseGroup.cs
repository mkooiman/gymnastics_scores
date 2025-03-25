namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexExerciseGroup(
    int Round = 0,
    bool AddTotal = false,
    List<RecreatexExercise> Exercises = null!)
{
    public RecreatexExerciseGroup() : this(
        Round: 0,
        AddTotal: false,
        Exercises: new List<RecreatexExercise>())
    { }
}