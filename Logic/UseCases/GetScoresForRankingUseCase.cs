using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Services;

namespace GymnasticScores.Logic.UseCases;

public interface IGetScoresForRankingUseCase
{
    Task<IEnumerable<Participation>> GetScores(string eventId, string rankingId);
}

public class GetScoresForRankingUseCase(IScoresProvider scoresProvider) : IGetScoresForRankingUseCase
{
    public Task<IEnumerable<Participation>> GetScores(string eventId, string rankingId)
    {
        return scoresProvider.GetScoresForRanking(eventId, rankingId);
    }
}