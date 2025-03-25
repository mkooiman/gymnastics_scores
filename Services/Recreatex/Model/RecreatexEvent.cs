using System.Text.Json.Serialization;

namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexEvent(
    string Id,
    string Group,
    string Title,
    string Venue,
    string DateFrom,
    string DateTo,
    string Locale,
    string LogoUrl,
    List<RecreatexDiscipline> Disciplines);

public record RecreatexDiscipline(
    string Id,
    string Group,
    string Title,
    [property: JsonPropertyName("discipline")]
    string DisciplineCode,
    string LogoUrl,
    bool ShowFlags);
    