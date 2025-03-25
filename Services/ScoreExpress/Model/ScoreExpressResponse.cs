namespace GymnasticScores.Services.ScoreExpress.Model;

public record ScoreExpressResponse<TData>(
    string Status = null!,
    TData Data = null!, // TData will be replaced with specific data types
    string Hash = null!) where TData : class;