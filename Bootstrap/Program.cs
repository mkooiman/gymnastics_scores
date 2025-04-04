using GymnasticScores.Api;
using GymnasticScores.Logic;
using GymnasticScores.Data;
using GymnasticScores.Logic.UseCases;
using GymnasticScores.Services;
using GymnasticScores.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug); // Capture everything
});
Api.Configure(builder.Services);
Data.Configure(builder, builder.Services);
Logic.Configure(builder.Services);
Services.Configure(builder.Services);
Tasks.Configure(builder.Services, builder.Configuration);
var app = builder.Build();
app.Use(async (context, next) =>
{
    app.Logger.LogDebug("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
    await next(context);
});
Api.Start(app);
Logic.Start(app);
Data.Start(app);
Services.Start(app);
Tasks.Start(app);
await app.StartAsync();

await using (var scope = app.Services.CreateAsyncScope())
{
    try
    {
        var useCase = scope.ServiceProvider.GetRequiredService<IUpdateEventsUseCase>();
        await useCase.UpdateEvents();
    }
    catch (Exception e)
    {
        app.Logger.LogError(e, "Error updating events");
    }
}

await app.WaitForShutdownAsync();