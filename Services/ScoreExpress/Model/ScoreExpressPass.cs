namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressPass(
    string Total = null!,
    List<ScoreExpressScoreValue> Values = null!)
{
    public ScoreExpressPass() : this(
        Total: null!,
        Values: new List<ScoreExpressScoreValue>())
    { }
}