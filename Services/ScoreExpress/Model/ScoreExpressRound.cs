namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressRound(
    int Index = 0,
    string Name = null!,
    string Status = null!);