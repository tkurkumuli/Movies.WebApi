using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Exceptions;
using Core.Application.Interfaces;
using MediatR;

namespace Core.Application.Features.Queries
{
    public class GetGetWatchListQuery
    {
        public record struct Request(Guid userid) : IRequest<IEnumerable<GetMovieDto>>;


        public class Handler : IRequestHandler<Request, IEnumerable<GetMovieDto>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper) => (this.unitOfWork, this.mapper) = (unitOfWork, mapper);

            public async Task<IEnumerable<GetMovieDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var movies = await unitOfWork.MovieRepository.GetWatchListByUserAsync(request.userid);

                if (movies.Count() == 0)
                    throw new DataNotFoundException("ჩანაწერი ვერ მოიძებნა");

                return mapper.Map<IEnumerable<GetMovieDto>>(movies); ;
            }
        }
    }
}
