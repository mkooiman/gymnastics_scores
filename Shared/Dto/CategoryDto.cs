namespace Shared.Dto;

public record CategoryDto
{
    public string Id { get; init; } = null!;
    public string Title { get; init; } = null!;
    public string Status { get; init; } = null!;
    public IReadOnlyList<CategoryRoundDto> Rounds { get; init; } = null!;
    
    public CategoryDto(string id, string title, string status, IReadOnlyList<CategoryRoundDto> rounds)
    {
        Id = id;
        Title = title;
        Status = status;
        Rounds = rounds;
    }
    
    public CategoryDto() { }
}
