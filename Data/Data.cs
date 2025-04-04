using GymnasticScores.Data.Repositories;
using GymnasticScores.Logic.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymnasticScores.Data;

public class Data
{
    public static void Configure(WebApplicationBuilder builder, IServiceCollection builderServices)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                               ?? "Data Source=app.db";
        
        builderServices.AddAutoMapper(typeof(DataMappingProfile));
        builderServices.AddDbContext<GymnasticsScoresDbContext>(options =>
            options.UseSqlite(connectionString));
        
        builderServices.AddScoped<IOrganizationRepository, OrganizationRepository>();
        builderServices.AddScoped<IEventRepository, EventRepository>();
        builderServices.AddScoped<IDisciplineRepository, DisciplineRepository>();
        builderServices.AddScoped<IParticipationRepository, ParticipationRepository>();
    }

    public static void Start(WebApplication app)
    {
        
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<GymnasticsScoresDbContext>();
            dbContext.Database.Migrate();
        }
    }
}