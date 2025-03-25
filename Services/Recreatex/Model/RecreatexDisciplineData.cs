namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexDisciplineData(
    string Id = null!,
    string Group = null!,
    string Title = null!,
    List<RecreatexRound> Rounds = null!,
    List<RecreatexRanking> Rankings = null!,
    string Status = null!,
    bool ScorePublication = false,
    string RankingPublication = null!)
{
    public RecreatexDisciplineData() : this(
        Id: null!,
        Group: null!,
        Title: null!,
        Rounds: new List<RecreatexRound>(),
        Rankings: new List<RecreatexRanking>(),
        Status: null!,
        ScorePublication: false,
        RankingPublication: null!)
    { }
}