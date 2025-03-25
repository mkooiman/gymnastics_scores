namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexPass(
    string Total = null!,
    List<RecreatexScoreValue> Values = null!)
{
    public RecreatexPass() : this(
        Total: null!,
        Values: new List<RecreatexScoreValue>())
    { }
}