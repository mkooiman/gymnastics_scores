using GymnasticScores.Logic.Repositories;
using GymnasticScores.Logic.Services;

namespace GymnasticScores.Logic.UseCases;

public interface IUpdateEventsUseCase
{
    Task UpdateEvents();   
}

public class UpdateEventsUseCase(
    IScoresProvider scoresProvider,
    IEventRepository eventRepository, 
    IOrganizationRepository organizationRepository)
    : IUpdateEventsUseCase
{
    public async Task UpdateEvents()
    {
        var organizations = await scoresProvider.GetOrganizations().ConfigureAwait(false);
        
        foreach (var organization in organizations)
        {
            await organizationRepository.Upsert(organization).ConfigureAwait(false);
            var events = await scoresProvider.GetEvents(organization.Id).ConfigureAwait(false);
            foreach (var @event in events)
            {
                await eventRepository.Upsert(organization, @event);
            }
        }
    }
    
}