namespace GymnasticScores.Logic.Model;

public record Discipline (
    string Id,
    string Group,
    string Title ,
    string DisciplineCode,
    string LogoUrl,
    bool? ShowFlags );