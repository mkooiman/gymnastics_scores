namespace Shared.Dto;
public record EventDto(
    string Id,
    string Group,
    string Title,
    string Venue,
    DateTime DateFrom,
    DateTime DateTo,
    string LogoUrl,
    List<DisciplineDto> Disciplines);
