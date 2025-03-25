
namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexEventData(
    string Id = null!,
    string Group = null!,
    string Title = null!,
    string Discipline = null!,
    DateTime DateFrom = default,
    DateTime DateTo = default,
    string Locale = null!,
    string LogoUrl = null!,
    bool ShowFlags = false,
    List<RecreatexRound> Rounds = null!,
    List<RecreatexCategory> Categories = null!,
    List<string> Clubs = null!)
{
    public RecreatexEventData() : this(
        Id: null!,
        Group: null!,
        Title: null!,
        Discipline: null!,
        DateFrom: default,
        DateTo: default,
        Locale: null!,
        LogoUrl: null!,
        ShowFlags: false,
        Rounds: new List<RecreatexRound>(),
        Categories: new List<RecreatexCategory>(),
        Clubs: new List<string>())
    { }
}