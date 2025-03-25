using GymnasticScores.Logic.Model;

namespace GymnasticScores.Logic.Services;

public interface IScoresProvider
{

    Task<IEnumerable<Organization>> GetOrganizations();
    
    Task<IEnumerable<Event>>GetEvents(string organizationId);
    
    Task<IEnumerable<Category>> GetCategoriesForEvent(string eventId);
    
    
    Task<IEnumerable<Ranking>> GetRankingsForDiscipline(string eventId, string disciplineId);
    Task<IEnumerable<Participation>> GetScoresForRanking(string eventId, string rankingId);
}