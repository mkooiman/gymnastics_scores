using AutoMapper;
using GymnasticScores.Logic.Model;
using Shared.Dto;

namespace GymnasticScores.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Organization, OrganizationDto>().ReverseMap();
        CreateMap<Event, EventDto>().ReverseMap();
        CreateMap<Discipline, DisciplineDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();    
        CreateMap<Round, CategoryRoundDto>().ReverseMap();
        CreateMap<Ranking,RankingDto>().ReverseMap();
        CreateMap<Participation,ParticipationDto>().ReverseMap();
        CreateMap<ScoreRound,ScoreRoundDto>().ReverseMap();
        CreateMap<ScoreValue,ScoreValueDto>().ReverseMap();
        CreateMap<Pass, PassDto>().ReverseMap();
        CreateMap<ScoreExercise, ScoreExerciseDto>().ReverseMap();
        
    }
    
}