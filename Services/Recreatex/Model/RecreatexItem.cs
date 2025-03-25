namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexItem(
    RecreatexParticipation Participation = null!,
    RecreatexRanking Ranking = null!);