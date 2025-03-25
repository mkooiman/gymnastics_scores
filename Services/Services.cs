using GymnasticScores.Logic.Services;
using GymnasticScores.Services.Recreatex;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace GymnasticScores.Services;

public static class Services
{
    
    public static void Configure(IServiceCollection builderServices)
    {
        builderServices.AddAutoMapper( typeof(MappingProfile) );
        builderServices.AddScoped<IScoresProvider, RecreatexService>();
        builderServices.AddRefitClient<IRecreatexClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://public.scoreexpress.be/api/"));
        ;
    }

    public static void Start(WebApplication app)
    {
        
        
    }
}