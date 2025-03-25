using AutoMapper;
using GymnasticScores.Logic.UseCases;
using Shared.Dto;

namespace GymnasticScores.Api;

public class OrganizationApi(IMapper mapper, IListOrganizationsUseCase useCase)
{
    public async Task<IEnumerable<OrganizationDto>> GetOrganizations()
    {
        var organizations = await useCase.GetOrganizations();
        return organizations.Select(mapper.Map<OrganizationDto>);
    }
}
    