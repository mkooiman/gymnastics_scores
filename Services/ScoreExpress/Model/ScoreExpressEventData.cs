
namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressEventData(
    string Id = null!,
    string Group = null!,
    string Title = null!,
    string Discipline = null!,
    DateTime DateFrom = default,
    DateTime DateTo = default,
    string Locale = null!,
    string LogoUrl = null!,
    bool ShowFlags = false,
    List<ScoreExpressRound> Rounds = null!,
    List<ScoreExpressCategory> Categories = null!,
    List<string> Clubs = null!)
{
    public ScoreExpressEventData() : this(
        Id: null!,
        Group: null!,
        Title: null!,
        Discipline: null!,
        DateFrom: default,
        DateTo: default,
        Locale: null!,
        LogoUrl: null!,
        ShowFlags: false,
        Rounds: new List<ScoreExpressRound>(),
        Categories: new List<ScoreExpressCategory>(),
        Clubs: new List<string>())
    { }
}