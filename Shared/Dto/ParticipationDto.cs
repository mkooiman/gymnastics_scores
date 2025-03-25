namespace Shared.Dto;

public record ParticipationDto(
    int Number,
    string Category, 
    List<string> Names,
    string Club,
    string Country,
    List<ScoreRoundDto> Scores,
    object? AaResults)
{
        
    public ParticipationDto() : this(
        Number: 0,
        Category: null!,
        Names: new List<string>(),
        Club: null!,
        Country: null!,
        Scores: new List<ScoreRoundDto>(),
        AaResults: null)
    { }
}