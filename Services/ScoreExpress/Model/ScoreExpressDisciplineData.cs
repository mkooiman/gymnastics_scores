namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressDisciplineData(
    string Id = null!,
    string Group = null!,
    string Title = null!,
    List<ScoreExpressRound> Rounds = null!,
    List<ScoreExpressRanking> Rankings = null!,
    string Status = null!,
    bool ScorePublication = false,
    string RankingPublication = null!)
{
    public ScoreExpressDisciplineData() : this(
        Id: null!,
        Group: null!,
        Title: null!,
        Rounds: new List<ScoreExpressRound>(),
        Rankings: new List<ScoreExpressRanking>(),
        Status: null!,
        ScorePublication: false,
        RankingPublication: null!)
    { }
}