using AutoMapper;
using MoviesAPI.Data.Dtos.Location;
using MoviesAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace MoviesAPI.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<CreateLocationDto, Location>();
            CreateMap<Location, ReadLocationDto>();
            CreateMap<UpdateLocationDto, Location>();
        }
    }
}
