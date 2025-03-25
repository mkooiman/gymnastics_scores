using GymnasticScores.Services.ScoreExpress.Model;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Refit;

namespace GymnasticScores.Services.ScoreExpress;

public interface IScoreExpressClient
{
    /*
     * Get all customers
     */
    [Get("/customers")]
    Task<List<ScoreExpressCustomer>> GetCustomers();
    
    /*
     * Get all events for a customer
     */
    [Get("/events/{customerId}")]
    Task<List<ScoreExpressEvent>> GetEvents(string customerId);
    
    /*
     * Get information about an event
     */
    [Get("/data/{eventId}/{eventId}")]
    Task<ScoreExpressResponse<EventData>> GetEventData(string eventId);
    
    /*
     * Gets the different categories in a category
     */
    [Get("/data/{organizationId}/{eventId}")]
    Task<ScoreExpressResponse<ScoreExpressEventData>> GetCategoryData(string organizationId, string eventId);
    
    /*
     * Gets the different categories in a category
     */
    [Get("/data/{eventId}/{categoryId}")]
    Task<ScoreExpressResponse<ScoreExpressDisciplineData>> GetRankingData(string eventId, string categoryId);

    /*
     * Gets the scores within a category
     */
    [Get("/data/{eventId}/{rankingId}")]
    Task<ScoreExpressResponse<ScoreExpressScoreData>> GetScoreData(string eventId, string rankingId);
}
