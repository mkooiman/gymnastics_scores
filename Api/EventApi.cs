using AutoMapper;
using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.UseCases;
using Shared.Dto;

namespace GymnasticScores.Api;

public class EventApi(IMapper mapper,
    IGetEventsUseCase getEventsUseCase,
    IGetCategoriesForEventUseCase getCategoriesForEventUseCase,
    IGetRankingsForCategoryUseCase getRankingsForCategoryUseCase,
    IGetScoresForRankingUseCase getScoresForCategoryUseCase)
{
    
    public async Task<IEnumerable<EventDto>> GetEvents( string organisationId )
    {
        var organizations = await getEventsUseCase.ListEvents(organisationId);
        
        return organizations.Select(mapper.Map<EventDto>);
    }

    public async Task<IEnumerable<ParticipationDto>> GetScores(string eventId, string rankingId)
    {
        var participations  = await getScoresForCategoryUseCase
            .GetScores(eventId, rankingId)
            .ConfigureAwait(false);

        var partLst = participations.ToList();
        
        return partLst.Select(mapper.Map<ParticipationDto>);
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories(string eventId)
    {
        var categories = await getCategoriesForEventUseCase.GetCategories(eventId);
        
        return categories.Select(mapper.Map<CategoryDto>);
    } 
    
    public async Task<IEnumerable<RankingDto>> GetRankings(string eventId, string disciplineId)
    {
        var rankings = await getRankingsForCategoryUseCase.GetRankings(eventId, disciplineId);
        
        return rankings.Select(mapper.Map<RankingDto>);
    }
}
