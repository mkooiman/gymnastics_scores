using GymnasticScores.Logic.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GymnasticScores.Logic;

public static class Logic
{
    public static void Configure(IServiceCollection builderServices)
    {
        builderServices.AddScoped<IGetEventsUseCase,GetEventsUseCase > ();
        builderServices.AddScoped<IListOrganizationsUseCase, ListOrganizationsUseCase>();
        builderServices.AddScoped<IGetCategoriesForEventUseCase, GetCategoriesForEventUseCase>();
        builderServices.AddScoped<IGetRankingsForCategoryUseCase, GetRankingsForCategoryUseCase>();
        builderServices.AddScoped<IRetrieveOrganizationsUseCase, RetrieveOrganizationsUseCase>();
        builderServices.AddScoped<IGetScoresForRankingUseCase, GetScoresForRankingUseCase>();
    }

    public static void Start(WebApplication app)
    {

        
    }
}