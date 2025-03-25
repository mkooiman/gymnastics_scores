namespace GymnasticScores.Logic.Model;



public record Category(
    string Id,
    string Title,
    string Status,
    IReadOnlyList<Round> Rounds
);

