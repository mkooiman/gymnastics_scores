using AutoMapper;
using GymnasticScores.Data.Entities;
using GymnasticScores.Logic.Model;

namespace GymnasticScores.Data;

public class DataMappingProfile: Profile
{
    public DataMappingProfile()
    {
        CreateMap<OrganizationEntity, Organization>().ReverseMap();
    }
    
}