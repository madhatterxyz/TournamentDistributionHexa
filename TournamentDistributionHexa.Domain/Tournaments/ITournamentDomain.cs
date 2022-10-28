using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public interface ITournamentDomain
    {
        List<TournamentMatch> Create(List<Player> players, List<Game> games);
        Task<List<TournamentMatch>> GetAll();
        int GetNumberOfOccurence(Player player, List<TournamentMatch> tournamentMatchs);
        Dictionary<Player,int> GetNumberOfOccurenceOfPlayers(List<Player> players, List<TournamentMatch> tournamentMatchs);
        List<Game> GetEvenlyDistributedGames(int gameCount, int playerCount);
    }
}