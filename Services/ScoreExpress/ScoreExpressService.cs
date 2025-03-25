using AutoMapper;
using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Services;
using GymnasticScores.Services.ScoreExpress.Model;

namespace GymnasticScores.Services.ScoreExpress;

public class ScoreExpressService(IMapper mapper, IScoreExpressClient client) : IScoresProvider
{

    public async Task<IEnumerable<Organization>> GetOrganizations()
    { 
        List<ScoreExpressCustomer> customers = await client.GetCustomers();
        return customers.Select(c => mapper.Map<Organization>(c));
    }
    
    public async Task<IEnumerable<Event>> GetEvents(string customerId)
    {
        List<ScoreExpressEvent> events = await client.GetEvents(customerId);
        
        return mapper.Map<List<Event>>(events);
    }

    public async Task<IEnumerable<Category>> GetCategoriesForEvent(string eventId)
    {
        ScoreExpressResponse<ScoreExpressEventData> response = await client.GetCategoryData(eventId, eventId);
        
        return response.Data.Categories.Select(c => mapper.Map<Category>(c));
    }

    public async Task<IEnumerable<Participation>> GetScoresForRanking(string eventId, string rankingId)
    {
        ScoreExpressResponse<ScoreExpressScoreData> response = await client.GetScoreData(eventId, rankingId);
        return response.Data.Items.Select(i => mapper.Map<Participation>(i.Participation));
    }

    public async Task<IEnumerable<Ranking>> GetRankingsForDiscipline(string eventId, string disciplineId)
    {
        ScoreExpressResponse<ScoreExpressDisciplineData> response = await client.GetRankingData(eventId, disciplineId);
        
        return response.Data.Rankings.Select(r => mapper.Map<Ranking>(r));
    }
    
    public async Task<IEnumerable<ScoreExpressExercise>> GetExercisesForCategory(string eventId, string categoryId)
    {
        ScoreExpressResponse<ScoreExpressScoreData> response = await client.GetScoreData(eventId, categoryId);
        return null;
        // return response.Data.Exercises.;
    }
}