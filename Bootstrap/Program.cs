using GymnasticScores.Api;
using GymnasticScores.Logic;
using GymnasticScores.Data;
using GymnasticScores.Logic.UseCases;
using GymnasticScores.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug); // Capture everything
});
Api.Configure(builder.Services);
Logic.Configure(builder.Services);
Data.Configure(builder, builder.Services);
Services.Configure(builder.Services);
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
await app.StartAsync();
await using (var serviceProvider = app.Services.CreateAsyncScope())
{
    var useCase = serviceProvider.ServiceProvider.GetRequiredService<IRetrieveOrganizationsUseCase>();
    await useCase.RetrieveOrganizations();
}

await app.WaitForShutdownAsync();