using MediatR;
using TournamentDistributionHexa.Application.Tournaments.Models;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Tournaments.Commands
{
    public class CreateTournamentCommand : IRequest<List<TournamentMatch>>
    {
        public string Name { get; }
        public List<Player> Players { get; }
        public List<Game> Games { get; }
        public CreateTournamentCommand(CreateTournamentRequest request)
        {
            Name = request.Name;
            Players = request.Players;
            Games = request.Games;
        }
    }
}
