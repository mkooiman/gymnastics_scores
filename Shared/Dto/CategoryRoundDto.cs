namespace Shared.Dto;


public record CategoryRoundDto
{
    public string Index { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Status { get; init; } = null!;
    
    public CategoryRoundDto(string index, string name, string status)
    {
        Index = index;
        Name = name;
        Status = status;
    }
    
    public CategoryRoundDto() { }
}