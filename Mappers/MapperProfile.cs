using AutoMapper;
using ef7_example.Domain.Entities;
using ef7_example.DTOs;
using NetTopologySuite;
using NetTopologySuite.Geometries;

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
            .ForMember(dto => dto.Genders, entity => entity.MapFrom(prop => prop.Genders.Select(g => g.Id)));

        CreateMap<MovieDTO,Movie>()
            .ForMember(m => m.Genders, dto => dto.MapFrom(g => g.Genders.Select(id => new Gender{Id = id})));

        
        CreateMap<Cinema,CinemaDto>()
            .ForMember(dto => dto.Latitude,ent => ent.MapFrom(prop => prop.Location.Y))
            .ForMember(dto => dto.Longitude, ent => ent.MapFrom(prop => prop.Location.X));

        var geometry = NtsGeometryServices.Instance.CreateGeometryFactory(srid:4326);
        
        CreateMap<CinemaDto,Cinema>()
            .ForMember(
                c => c.Location,
                dto=>dto.MapFrom(u => geometry.CreatePoint(new Coordinate(u.Longitude,u.Latitude))));

        CreateMap<CinemaOfferCreateDto, CinemaOffer>();
        CreateMap<MovieTheaterDto, MovieTheater>();
    }
}