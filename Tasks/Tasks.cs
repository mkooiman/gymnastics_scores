using GymnasticScores.Logic.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymnasticScores.Tasks;

public class Tasks
{
    
    public static void Configure(IServiceCollection builderServices, IConfiguration configuration)
    {
        builderServices.AddHostedService<UpdateEventsScheduler>();
    }

    public static void Start(WebApplication app)
    {
    }
}