using System.Globalization;
using AutoMapper;
using GymnasticScores.Logic.Model;
using GymnasticScores.Services.ScoreExpress.Model;

namespace GymnasticScores.Services.ScoreExpress;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ScoreExpressCustomer, Organization>().ReverseMap();
        CreateMap<ScoreExpressCategory, Category>().ReverseMap();
        CreateMap<ScoreExpressEvent, Event>()
            .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture)))
            .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture))).ReverseMap();
        CreateMap<RecreatexDiscipline, Discipline>();
        CreateMap<ScoreExpressRound, Round>();
        CreateMap<ScoreExpressRanking, Ranking>().ReverseMap();
        CreateMap<ScoreExpressParticipation, Participation>().ReverseMap();
        CreateMap<ScoreExpressScoreRound, ScoreRound>();
        CreateMap<ScoreExpressScoreValue, ScoreValue>();
        CreateMap<ScoreExpressPass, Pass>();
        CreateMap<ScoreExpressScoreExercise, ScoreExercise>();
        AllowNullCollections = true;
    }
}