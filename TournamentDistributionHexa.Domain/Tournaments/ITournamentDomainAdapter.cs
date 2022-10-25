using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public interface ITournamentDomainAdapter
    {
        List<TournamentMatch> Create(List<Player> players, List<Game> games);
    }
}