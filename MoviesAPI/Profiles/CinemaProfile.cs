using AutoMapper;
using MoviesAPI.Data.Dtos.Cinema;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class CinemaProfile: Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
