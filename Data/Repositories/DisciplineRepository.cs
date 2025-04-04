using AutoMapper;
using GymnasticScores.Data;
using GymnasticScores.Data.Entities;
using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Repositories;
using Microsoft.EntityFrameworkCore;

public class DisciplineRepository : IDisciplineRepository
{
    private readonly GymnasticsScoresDbContext dbContext;
    private readonly IMapper mapper;

    public DisciplineRepository(GymnasticsScoresDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<List<Discipline>> All()
    {
        var entities = await dbContext.Disciplines.ToListAsync();
        return entities.Select(e => mapper.Map<Discipline>(e)).ToList();
    }
    
    public async Task<Discipline> Get(string id)
    {
        var entity = await dbContext.Disciplines.FindAsync(id);
        return entity != null ? mapper.Map<Discipline>(entity) : null;
    }

    public async Task Upsert(Discipline discipline)
    {
        var existing = await dbContext.Disciplines.FindAsync(discipline.Id);
        if (existing != null)
        {
            mapper.Map(discipline, existing);
        }
        else
        {
            var newEntity = mapper.Map<DisciplineEntity>(discipline);
            newEntity.Added = DateTime.UtcNow;
            await dbContext.Disciplines.AddAsync(newEntity);
        }
        await dbContext.SaveChangesAsync();
    }
    
    public async Task Delete(string id)
    {
        var entity = await dbContext.Disciplines.FindAsync(id);
        if (entity != null)
        {
            dbContext.Disciplines.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Discipline>> GetForEvent(string eventId)
    {
        var entities = await dbContext.Disciplines
            .Where(d => d.Event != null && d.Event.Id == eventId)
            .ToListAsync();
        return entities.Select(e => mapper.Map<Discipline>(e)).ToList();
    }
}