using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Services;

namespace GymnasticScores.Logic.UseCases;

public interface IGetEventsUseCase
{
    Task<List<Event>> ListEvents(string organizationId);
}

public class GetEventsUseCase(IScoresProvider _scoresProvider) : IGetEventsUseCase
{
    
    
    public async Task<List<Event>> ListEvents(string organizationId)
    {
        var events =  await _scoresProvider.GetEvents(organizationId);
        return events.ToList();
    }
}