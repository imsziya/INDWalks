using AutoMapper;

namespace INDWalks.Mapper;

public class RegionProfile : Profile
{
    public RegionProfile()
    {
        CreateMap<Models.Domain.Region,Models.DTO.Region>().ReverseMap();
    }
}
