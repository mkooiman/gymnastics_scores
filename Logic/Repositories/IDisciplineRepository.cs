using GymnasticScores.Logic.Model;

namespace GymnasticScores.Logic.Repositories;

public interface IDisciplineRepository
{
    Task<List<Discipline>> All();
    Task<Discipline> Get(string id);
    Task Upsert(Discipline discipline);
    Task Delete(string id);
    Task<List<Discipline>> GetForEvent(string eventId);
}