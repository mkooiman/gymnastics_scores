namespace Shared.Dto;

public record ScoreRoundDto(
    int Round = 0,
    List<ScoreExerciseDto> Exercises = null!) 
{
     public ScoreRoundDto(): this(
         Round: 0,
         Exercises: new List<ScoreExerciseDto>())
     { }
    
    
}