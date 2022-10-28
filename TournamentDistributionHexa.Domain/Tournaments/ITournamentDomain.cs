using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public interface ITournamentDomain
    {
        List<TournamentMatch> Create(string nom, List<Player> players, List<Game> games);
        Task<List<TournamentMatch>> GetAll();
        List<Game> GetEvenlyDistributedGames(List<Game> games, int playerCount);
    }
}