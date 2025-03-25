using AutoMapper;
using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Services;
using GymnasticScores.Services.Recreatex.Model;

namespace GymnasticScores.Services.Recreatex;

public class RecreatexService(IMapper mapper, IRecreatexClient client) : IScoresProvider
{

    public async Task<IEnumerable<Organization>> GetOrganizations()
    { 
        List<RecreatexCustomer> customers = await client.GetCustomers();
        return customers.Select(c => mapper.Map<Organization>(c));
    }
    
    public async Task<IEnumerable<Event>> GetEvents(string customerId)
    {
        List<RecreatexEvent> events = await client.GetEvents(customerId);
        
        return mapper.Map<List<Event>>(events);
    }

    public async Task<IEnumerable<Category>> GetCategoriesForEvent(string eventId)
    {
        RecreatexResponse<RecreatexEventData> response = await client.GetCategoryData(eventId, eventId);
        
        return response.Data.Categories.Select(c => mapper.Map<Category>(c));
    }

    public async Task<IEnumerable<Participation>> GetScoresForRanking(string eventId, string rankingId)
    {
        RecreatexResponse<RecreatexScoreData> response = await client.GetScoreData(eventId, rankingId);
        return response.Data.Items.Select(i => mapper.Map<Participation>(i.Participation));
    }

    public async Task<IEnumerable<Ranking>> GetRankingsForDiscipline(string eventId, string disciplineId)
    {
        RecreatexResponse<RecreatexDisciplineData> response = await client.GetRankingData(eventId, disciplineId);
        
        return response.Data.Rankings.Select(r => mapper.Map<Ranking>(r));
    }
    
    public async Task<IEnumerable<RecreatexExercise>> GetExercisesForCategory(string eventId, string categoryId)
    {
        RecreatexResponse<RecreatexScoreData> response = await client.GetScoreData(eventId, categoryId);
        return null;
        // return response.Data.Exercises.;
    }
}