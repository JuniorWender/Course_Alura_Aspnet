using AutoMapper;
using MoviesAPI.Data.Dtos.Section;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<CreateSectionDto, Section>();
            CreateMap<Section, ReadSectionDto>();
        }
    }
}
