using GymnasticScores.Logic.Model;

namespace GymnasticScores.Logic.Repositories;

public interface IEventRepository
{
    
    Task<List<Event>> GetForOrganization(string organizationId);
    
    Task<Event> Get(string id);
    
    Task Upsert(Organization org, Event @event);
    
    // Task UpsertRange(Organization org, List<Event> events);
    
    Task Delete(string id);
    
    Task<List<Event>> All();
    
}