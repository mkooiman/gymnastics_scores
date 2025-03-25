using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Services;

namespace GymnasticScores.Logic.UseCases;

public interface IGetCategoriesForEventUseCase
{
    Task<IEnumerable<Category>> GetCategories(string eventId);
}


class GetCategoriesForEventUseCase : IGetCategoriesForEventUseCase
{
    private readonly IScoresProvider _scoresProvider;

    public GetCategoriesForEventUseCase(IScoresProvider scoresProvider)
    {
        _scoresProvider = scoresProvider;
    }
    
    public async Task<IEnumerable<Category>> GetCategories(string eventId)
    {
        return await _scoresProvider.GetCategoriesForEvent(eventId);
    }
    
}