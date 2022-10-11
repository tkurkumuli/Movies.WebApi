using Core.Application.Enums;
using Core.Application.Features.Commands;
using Core.Application.Features.Queries;
using Core.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MoviesController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("GetSearchedMovies")]
        public async Task<MovieResponseModel> Get([FromQuery] string name, Language? lang = Language.En)
        {
            return await mediator.Send(new GetMoviesFilteredQuery.Request(name, lang ));
        }

        [HttpPost("AddMovieToWatchList")]
        public async Task<IActionResult> Add([FromForm] CreateMovieCommand.Request request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie([FromForm] UpdateMovieCommand.Request request)
        {
           await mediator.Send(request);
           return Ok();
        }

        [HttpGet("GetWatchList")]
        public async Task<IActionResult> Get(Guid userid)
        {
            var result = await mediator.Send(new GetGetWatchListQuery.Request(userid));
            return Ok(result);
        }
    }
}
 