using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Repositories;
using GymnasticScores.Logic.Services;

namespace GymnasticScores.Logic.UseCases;

public interface IGetEventsUseCase
{
    Task<List<Event>> ListEvents(string organizationId);
}

public class GetEventsUseCase(IEventRepository eventRepository) : IGetEventsUseCase
{
    
    
    public async Task<List<Event>> ListEvents(string organizationId)
    {
        var events = await eventRepository.GetForOrganization(organizationId);
        return events.ToList();
    }
}