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
            CreateMap<Section, ReadSectionDto>()
                .ForMember(dto => dto.MovieStartHour, opts => opts
                .MapFrom(dto => dto.MovieHour.AddMinutes(dto.Movie.Duration * (-1))));
        }
    }
}
