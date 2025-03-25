namespace GymnasticScores.Logic.Model;

public record ScoreRound( 
    int Round,
    List<ScoreExercise> Exercises
){
    ScoreRound(): this(0, new List<ScoreExercise>()) { }
}