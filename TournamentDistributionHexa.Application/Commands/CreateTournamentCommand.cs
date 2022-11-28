using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Commands
{
    public class CreateTournamentCommand : IRequest<IEnumerable<TournamentMatch>>
    {
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<Player> Players { get; }
        public List<Game> Games { get; }
        public CreateTournamentCommand(CreateTournamentRequest request)
        {
            Name = request.Name;
            Players = request.Players;
            Games = request.Games;
            StartDate = request.StartDate;
            EndDate = request.EndDate;
        }
    }
}
