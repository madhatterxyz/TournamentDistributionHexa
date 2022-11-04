using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TournamentDistributionHexa.Application.Tournaments.Commands;
using TournamentDistributionHexa.Application.Tournaments.Models;
using TournamentDistributionHexa.Application.Tournaments.Queries;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Tournaments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Tournoi>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> All()
        {
            return Ok(await _mediator.Send(new GetAllTournamentsQuery()));
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<TournamentMatch>), (int)HttpStatusCode.Created)]
        public IActionResult Create([FromBody] CreateTournamentRequest tournoi)
        {
            return Created(string.Empty, _mediator.Send(new CreateTournamentCommand(tournoi)));
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<TournamentMatch>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] EditTournamentRequest tournoi)
        {
            return Ok(await _mediator.Send(new EditTournamentCommand(tournoi)));
        }
    }
}