using System.Text.Json.Serialization;

namespace GymnasticScores.Logic.Model;

public record Event(
    string Id,
    string Group,
    string Title,
    string Venue,
    DateTime DateFrom,
    DateTime DateTo,
    string LogoUrl,
    List<Discipline> Disciplines);

