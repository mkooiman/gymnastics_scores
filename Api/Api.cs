using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GymnasticScores.Api;

public static class Api
{
    public static void Configure(IServiceCollection builderServices)
    {
        builderServices.AddScoped<EventApi>();
        builderServices.AddScoped<OrganizationApi> ();
        builderServices.AddAutoMapper(typeof(MappingProfile));
    }

    public static void Start(WebApplication app)
    {
        
        app.MapGet("/organizations", ( OrganizationApi organizationApi) => organizationApi.GetOrganizations());
        app.MapGet("/events/{organizationId}", ( EventApi eventApi, string organizationId) => eventApi.GetEvents(organizationId));
        app.MapGet("/events/{eventId}/categories", (EventApi eventApi, string eventId) => eventApi.GetCategories(eventId));
        app.MapGet("/events/{eventId}/{disciplineId}/rankings", (EventApi eventApi, string eventId, string disciplineId) => eventApi.GetRankings(eventId, disciplineId));
        app.MapGet("/events/{eventId}/{rankingId}/scoreboard", (EventApi eventApi, string eventId, string rankingId) => eventApi.GetScores(eventId, rankingId));
        
    }
}