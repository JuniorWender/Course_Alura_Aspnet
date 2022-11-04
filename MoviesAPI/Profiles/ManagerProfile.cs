using AutoMapper;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<Manager, ReadManagerDto>();
               /* .ForMember(manager => manager.Cinemas, opts => opts
                .MapFrom(manager => manager.Cinemas.Select
                (cinema => new cinema == { c.Id, c.Location, c.LocationId })); */
        }
    }
}
