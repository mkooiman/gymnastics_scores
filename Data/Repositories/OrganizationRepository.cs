using AutoMapper;
using GymnasticScores.Data.Entities;
using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymnasticScores.Data.Repositories;

public class OrganizationRepository(GymnasticsScoresDbContext dbContext,IMapper mapper) : IOrganizationRepository
{
    public Task<IEnumerable<Organization>> All()
    {
        return Task.FromResult<IEnumerable<Organization>>(dbContext.Organizations.Select(o=>mapper.Map<Organization>(o)));
    }

    public async Task Upsert(Organization organization)
    {
        var existing = await GetOrganizationById(organization.Id);
        if (existing != null)
        {
            mapper.Map(organization, existing);
        }
        else
        {
            var entity = mapper.Map<OrganizationEntity>(organization);    
            entity.Added = DateTime.UtcNow;
            await dbContext.Organizations.AddAsync(entity);
        }

        await dbContext.SaveChangesAsync();
    }
    
    public Task<OrganizationEntity?> GetOrganizationById(string id)
    {
        return dbContext.Organizations.FirstOrDefaultAsync(o=>o.Id == id);
    }
}