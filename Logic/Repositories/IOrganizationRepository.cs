using GymnasticScores.Logic.Model;

namespace GymnasticScores.Logic.Repositories;

public interface IOrganizationRepository
{
    Task<IEnumerable<Organization>> All();
    
    Task Upsert(Organization organization);
}