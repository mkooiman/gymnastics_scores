namespace Shared.Dto;


public record PassDto(
    string Total = null!,
    List<ScoreValueDto> Values = null!)
{
    public PassDto() : this(
        Total: null!,
        Values: new List<ScoreValueDto>())
    { }
}