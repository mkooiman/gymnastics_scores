using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Repositories;

namespace GymnasticScores.Logic.UseCases;

public interface IListOrganizationsUseCase
{
    Task<List<Organization>> GetOrganizations();
}

internal class ListOrganizationsUseCase(IOrganizationRepository repository) : IListOrganizationsUseCase
{

    private readonly IOrganizationRepository Repository = repository;


    public async Task<List<Organization>> GetOrganizations()
    {
        var organizations = await Repository.All();
        return organizations.ToList();
    }
}