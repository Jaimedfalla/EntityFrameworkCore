using AutoMapper;
using ef7_example.Domain.Entities;
using ef7_example.DTOs;

namespace ef7_example.Mappers;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<GenderDto,Gender>().ReverseMap();
        CreateMap<ActorDto,Actor>().ReverseMap();
        CreateMap<Actor,SimpleActorDTO>().ReverseMap();
        CreateMap<MovieActorDto,MovieActor>().ReverseMap();
        CreateMap<CommentDTO,Comment>().ReverseMap();

        CreateMap<Movie,MovieDTO>()
            .ForMember(dto => dto.CinemaDtos,entity => entity.MapFrom(prop => prop.MovieTheaters.Select(t => t.Cinema)))
            .ForMember(dto => dto.Actors,entity => entity.MapFrom(prop => prop.MoviesActors.Select(a => a.Actor)))
            .ReverseMap();

        
        CreateMap<Cinema,CinemaDto>()
            .ForMember(dto => dto.Latitude,ent => ent.MapFrom(prop => prop.Location.Y))
            .ForMember(dto => dto.Longitude, ent => ent.MapFrom(prop => prop.Location.X));
    }
}