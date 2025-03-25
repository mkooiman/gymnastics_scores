using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Repositories;
using GymnasticScores.Logic.Services;

namespace GymnasticScores.Logic.UseCases;

public interface IRetrieveOrganizationsUseCase
{
    Task<List<Organization>> RetrieveOrganizations();
}

public class RetrieveOrganizationsUseCase(IScoresProvider provider, IOrganizationRepository repository) : IRetrieveOrganizationsUseCase
{
    private  IScoresProvider _provider = provider;
    private IOrganizationRepository _repository = repository;
    
    public async Task<List<Organization>> RetrieveOrganizations()
    {
        var organizations = await _provider.GetOrganizations().ConfigureAwait(false);
        
        var orgList = organizations.ToList();
        foreach (var organization in orgList)
        {
            await _repository.Upsert(organization).ConfigureAwait(false);
        }

        return orgList;
    }
}