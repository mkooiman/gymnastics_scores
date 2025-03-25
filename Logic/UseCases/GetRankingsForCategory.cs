using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Services;

namespace GymnasticScores.Logic.UseCases;

public interface IGetRankingsForCategoryUseCase
{
    Task<IEnumerable<Ranking>> GetRankings(string eventId, string disciplineId);   
}

public class GetRankingsForCategoryUseCase(IScoresProvider scoresProvider) : IGetRankingsForCategoryUseCase
{
    public Task<IEnumerable<Ranking>> GetRankings(string eventId, string disciplineId)
    {
        return scoresProvider.GetRankingsForDiscipline(eventId, disciplineId);
    }
}