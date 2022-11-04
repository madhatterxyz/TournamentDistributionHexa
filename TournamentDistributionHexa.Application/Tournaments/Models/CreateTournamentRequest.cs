using TournamentDistributionHexa.Domain;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;

namespace TournamentDistributionHexa.Application.Tournaments.Models
{
    public class CreateTournamentRequest
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Game> Games { get; set; }
    }
}
