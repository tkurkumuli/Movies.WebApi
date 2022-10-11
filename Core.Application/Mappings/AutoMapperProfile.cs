using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Features.Commands;
using Core.Domain.Entities;

namespace Core.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateMovieCommand.Request, Movie>();
            CreateMap<Movie, GetMovieDto>();
        }
    }
}
