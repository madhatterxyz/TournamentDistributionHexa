using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public class TournamentDomain : ITournamentDomain
    {
        public const int NUMBER_PLAYERS_PER_MATCH = 3;
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
            return list;
        }
    }
}