using GymnasticScores.Logic.Model;

namespace GymnasticScores.Logic.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> All();
    Task<Category> Get(string id);
    Task Upsert(Category category);
    Task Delete(string id);
}