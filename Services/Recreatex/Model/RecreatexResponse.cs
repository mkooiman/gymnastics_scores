namespace GymnasticScores.Services.Recreatex.Model;

public record RecreatexResponse<TData>(
    string Status = null!,
    TData Data = null!, // TData will be replaced with specific data types
    string Hash = null!) where TData : class;