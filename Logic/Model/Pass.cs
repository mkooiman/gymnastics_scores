namespace GymnasticScores.Logic.Model;


public record Pass(
    string Total = null!,
    List<ScoreValue> Values = null!)
{
    public Pass() : this(
        Total: null!,
        Values: new List<ScoreValue>())
    { }
}