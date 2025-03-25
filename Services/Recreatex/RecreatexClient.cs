using GymnasticScores.Services.Recreatex.Model;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Refit;

namespace GymnasticScores.Services.Recreatex;

public interface IRecreatexClient
{
    /*
     * Get all customers
     */
    [Get("/customers")]
    Task<List<RecreatexCustomer>> GetCustomers();
    
    /*
     * Get all events for a customer
     */
    [Get("/events/{customerId}")]
    Task<List<RecreatexEvent>> GetEvents(string customerId);
    
    /*
     * Get information about an event
     */
    [Get("/data/{eventId}/{eventId}")]
    Task<RecreatexResponse<EventData>> GetEventData(string eventId);
    
    /*
     * Gets the different categories in a category
     */
    [Get("/data/{organizationId}/{eventId}")]
    Task<RecreatexResponse<RecreatexEventData>> GetCategoryData(string organizationId, string eventId);
    
    /*
     * Gets the different categories in a category
     */
    [Get("/data/{eventId}/{categoryId}")]
    Task<RecreatexResponse<RecreatexDisciplineData>> GetRankingData(string eventId, string categoryId);

    /*
     * Gets the scores within a category
     */
    [Get("/data/{eventId}/{rankingId}")]
    Task<RecreatexResponse<RecreatexScoreData>> GetScoreData(string eventId, string rankingId);
}
