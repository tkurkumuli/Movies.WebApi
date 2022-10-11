using AutoMapper;
using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Core.Application.Features.Commands
{
    public class CreateMovieCommand
    {
        public record class Request : IRequest
        {
            public string Id { get; set; }
            public string ResultType { get; set; }
            public string ImagePath { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public Guid UserId { get; set; }

        }
        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper) => (this.unitOfWork, this.mapper) = (unitOfWork, mapper);

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                //check if movie already exist in db by user
                var dbInfo = await unitOfWork.MovieRepository.GetUser2movieByIdAsync(request.UserId);
                if (dbInfo != null && (dbInfo.UserId == request.UserId && dbInfo.MovieId == request.Id))
                    throw new DataAlreadyExistsException("მსგავსი ფილმი უკვე დამატებული გაქვთ სანახავ სიაში");

                //add movie
                var movie = mapper.Map<Movie>(request);
                await unitOfWork.MovieRepository.CreateAsync(movie);

                //add new user2Movie
                var u2m = new User2Movie();
                u2m.UserId = request.UserId;
                u2m.MovieId = request.Id;
                await unitOfWork.MovieRepository.CreateUser2MovieAsync(u2m);

                await unitOfWork.SaveAsync();
                return Unit.Value;
            }

        }

        public sealed class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotNull().WithMessage("Id ველი ცარიელია");
                RuleFor(x => x.ResultType).NotEmpty().WithMessage("ტიპის ველი ცარიელია");
                RuleFor(x => x.ImagePath).NotEmpty().WithMessage("ფოტოს ველი ცარიელია");
                RuleFor(x => x.Title).NotEmpty().WithMessage("დასახელების ველი ცარიელია");
            }
        }
    }
}
