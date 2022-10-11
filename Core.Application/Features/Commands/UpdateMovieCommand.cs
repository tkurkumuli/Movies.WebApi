using Core.Application.Exceptions;
using Core.Application.Interfaces;
using MediatR;

namespace Core.Application.Features.Commands
{
    public class UpdateMovieCommand
    {
        public sealed record class Request : IRequest
        {
            public Guid Id { get; set; }
            public bool IsWatched { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork) => (this.unitOfWork) = (unitOfWork);
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var user2movie = await unitOfWork.MovieRepository.GetUser2movieByIdAsync(request.Id);

                if (user2movie == null)
                    throw new DataNotFoundException("ჩანაწერი ვერ მოიძებნა");

                user2movie.IsWatched = request.IsWatched;
                await unitOfWork.SaveAsync();
                return Unit.Value; ;
            }
        }
    }
}
