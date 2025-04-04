using GymnasticScores.Logic.Model;

namespace GymnasticScores.Logic.Repositories;

public interface IRoundRepository
{
    Task<List<Round>> All();
    Task<Round> Get(string id);
    Task Upsert(Round round);
    Task Delete(string id);
}