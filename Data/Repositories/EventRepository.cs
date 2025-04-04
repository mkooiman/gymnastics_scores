using AutoMapper;
using GymnasticScores.Data.Entities;
using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymnasticScores.Data.Repositories;

public class EventRepository(GymnasticsScoresDbContext dbContext, IDisciplineRepository disciplineRepository, IMapper mapper) : IEventRepository
{
    public async Task<List<Event>> GetForOrganization(string organizationId)
    {
        var events = await dbContext.Events
            .Where(e => e.Organization.Id == organizationId)
            .ToListAsync();
        return events.Select(e => mapper.Map<Event>(e)).ToList();
    }

    public async Task<Event> Get(string id)
    {
        var eventEntity = await dbContext.Events.FindAsync(id);
        return eventEntity != null ? mapper.Map<Event>(eventEntity) : null;
    }

    public async Task Upsert(Organization org, Event @event)
    {
        var orgEntity = await dbContext.Organizations.FirstAsync(o => o.Id == org.Id);
        var existingEvent = await dbContext.Events
            .Include(e => e.Disciplines) // Eager load disciplines
            .FirstOrDefaultAsync(e => e.Id == @event.Id);

        if (existingEvent != null)
        {
            mapper.Map(@event, existingEvent);
            existingEvent.Organization = orgEntity;
            await UpsertDisciplinesInPlace(@event, existingEvent);
        }
        else
        {
            var eventEntity = mapper.Map<EventEntity>(@event);
            eventEntity.Organization = orgEntity;
            eventEntity.Added = DateTime.UtcNow;
            await UpsertDisciplinesInPlace(@event, eventEntity);
            await dbContext.Events.AddAsync(eventEntity);
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task UpsertDisciplinesInPlace(Event @event, EventEntity eventEntity)
    {
        foreach (var discipline in @event.Disciplines)
        {
            var existingDiscipline = eventEntity.Disciplines
                                         ?.FirstOrDefault(d => d.Id == discipline.Id)
                                     ?? await dbContext.Disciplines.FirstOrDefaultAsync(d => d.Id == discipline.Id);

            if (existingDiscipline != null)
            {
                mapper.Map(discipline, existingDiscipline);
                existingDiscipline.Event = eventEntity;
            }
            else
            {
                var disciplineEntity = mapper.Map<DisciplineEntity>(discipline);
                disciplineEntity.Added = DateTime.UtcNow;
                disciplineEntity.Event = eventEntity;
                eventEntity.Disciplines ??= new List<DisciplineEntity>();
                eventEntity.Disciplines.Add(disciplineEntity);
            }
        }
    }
    
    public async Task Delete(string id)
    {
        var eventEntity = await dbContext.Events.FirstOrDefaultAsync( e=> e.Id == id);
        if (eventEntity != null)
        {
            dbContext.Events.Remove(eventEntity);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Event>> All()
    {
        var events = await dbContext.Events.ToListAsync();
        return events.Select(e => mapper.Map<Event>(e)).ToList();
    }
}