using Core.Application.Enums;
using Core.Application.Exceptions;
using Core.Application.Interfaces.Services;
using Core.Application.Models;
using MediatR;

namespace Core.Application.Features.Queries
{
    public class GetMoviesFilteredQuery
    {
        public record struct Request(string Name, Language? Lang = Language.En) : IRequest<MovieResponseModel>;


        public class Handler : IRequestHandler<Request, MovieResponseModel>
        {
            private readonly IMovieService movieService;

            public Handler(IMovieService movieService) => (this.movieService) = (movieService);

            public async Task<MovieResponseModel> Handle(Request request, CancellationToken cancellationToken)
            {
                var movies = await movieService.GetMoviesFiltered(request.Name, request.Lang);

                if (movies.Results.Count == 0)
                    throw new DataNotFoundException("ჩანაწერი ვერ მოიძებნა");

                return movies;
            }
        }
    }

}
