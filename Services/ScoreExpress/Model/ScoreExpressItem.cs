namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressItem(
    ScoreExpressParticipation Participation = null!,
    ScoreExpressRanking Ranking = null!);