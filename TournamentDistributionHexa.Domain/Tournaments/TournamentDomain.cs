using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public class TournamentDomain : ITournamentDomain
    {
        public const int NUMBER_PLAYERS_PER_MATCH = 3;
        private readonly ITournamentMatchRepository _repositoryAdapter;
        private readonly IConfiguration _configuration;
        public TournamentDomain(ITournamentMatchRepository tournamentRepositoryAdapter, IConfiguration configuration)
        {
            _repositoryAdapter = tournamentRepositoryAdapter;
        }
        public List<TournamentMatch> Create(List<Player> players, List<Game> games)
        {
            var list = new List<TournamentMatch>();
            foreach (var game in games)
            {
                int numberOfPlayersCounter = 0;
                int numberOfMatchesCounter = 1;
                while (numberOfPlayersCounter < players.Count)
                {
                    List<MatchScore> scoreList = new List<MatchScore>();
                    while (numberOfPlayersCounter < NUMBER_PLAYERS_PER_MATCH * numberOfMatchesCounter)
                    {
                        scoreList.Add(new MatchScore() { Player = players[numberOfPlayersCounter] });
                        numberOfPlayersCounter++;
                    }
                    list.Add(new TournamentMatch() { Game = game, Scores = scoreList });
                    numberOfMatchesCounter++;
                }
            }
            _repositoryAdapter.Create(list);
            return list;
        }

        public async Task<List<TournamentMatch>> GetAll()
        {
            return _repositoryAdapter.GetAll();
        }
        public int GetNumberOfOccurence(Player player, List<TournamentMatch> tournamentMatchs)
        {
            return tournamentMatchs.Count(x=>x.Scores.Any(y=>y.Player.Equals(player)));
        }
        public Dictionary<Player, int> GetNumberOfOccurenceOfPlayers(List<Player> players, List<TournamentMatch> tournamentMatchs)
        {
            Dictionary<Player, int> result = new Dictionary<Player, int>();
            foreach (Player player in players)
            {
                result.Add(player,GetNumberOfOccurence(player, tournamentMatchs));
            }
            return result;
        }
    }
}