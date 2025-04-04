using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymnasticScores.Tasks;

using System;
using System.Threading;
using System.Threading.Tasks;
using Cronos;
using Logic.UseCases;
using Microsoft.Extensions.Hosting;

public class UpdateEventsScheduler : BackgroundService
{
    private readonly CronExpression _cronExpression;
    private readonly IServiceProvider _serviceProvider;
    
    public UpdateEventsScheduler(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        var cronExpressionString = configuration["CronSettings:UpdateEventsCron"];
        _cronExpression = CronExpression.Parse(cronExpressionString);
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        UpdateEvents();
        while (!stoppingToken.IsCancellationRequested)
        {
            var nextOccurrence = _cronExpression.GetNextOccurrence(DateTime.UtcNow);
            if (nextOccurrence.HasValue)
            {
                var delay = nextOccurrence.Value - DateTime.UtcNow;
                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, stoppingToken);
                }

                if (!stoppingToken.IsCancellationRequested)
                {
                    await UpdateEvents();
                }
            }
        }
    }
    
    private Task UpdateEvents()
    {
        using var scope = _serviceProvider.CreateScope();
        var updateEventsUseCase = scope.ServiceProvider.GetRequiredService<IUpdateEventsUseCase>();
        return updateEventsUseCase.UpdateEvents();
    }
}