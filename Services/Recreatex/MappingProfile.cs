using System.Globalization;
using AutoMapper;
using GymnasticScores.Logic.Model;
using GymnasticScores.Services.Recreatex.Model;

namespace GymnasticScores.Services.Recreatex;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RecreatexCustomer, Organization>().ReverseMap();
        CreateMap<RecreatexCategory, Category>().ReverseMap();
        CreateMap<RecreatexEvent, Event>()
            .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture)))
            .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture))).ReverseMap();
        CreateMap<RecreatexDiscipline, Discipline>();
        CreateMap<RecreatexRound, Round>();
        CreateMap<RecreatexRanking, Ranking>().ReverseMap();
        CreateMap<RecreatexParticipation, Participation>().ReverseMap();
        CreateMap<RecreatexScoreRound, ScoreRound>();
        CreateMap<RecreatexScoreValue, ScoreValue>();
        CreateMap<RecreatexPass, Pass>();
        CreateMap<RecreatexScoreExercise, ScoreExercise>();
        AllowNullCollections = true;
    }
}