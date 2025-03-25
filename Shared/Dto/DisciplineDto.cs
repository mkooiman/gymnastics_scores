using GymnasticScores.Logic.Model;

namespace Shared.Dto;


public record DisciplineDto
{
    public string Id { get; init; } = null!;
    public string Group { get; init; } = null!;
    public string Title { get; init; } = null!;
    public string DisciplineCode { get; init; }
    public string LogoUrl { get; init; } = null!;
    public bool? ShowFlags { get; init; }
    
    public DisciplineDto(string id, string group, string title, string disciplineCode, string logoUrl, bool? showFlags)
    {
        Id = id;
        Group = group;
        Title = title;
        DisciplineCode = disciplineCode;
        LogoUrl = logoUrl;
        ShowFlags = showFlags;
    }
    
    public DisciplineDto() { }
}