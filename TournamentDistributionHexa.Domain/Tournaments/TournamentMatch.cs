using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Score;

namespace TournamentDistributionHexa.Domain.Tournament;

public record TournamentMatch
{
    public TournamentMatch(Game game)
    {
        Game = game;
        Scores = new List<MatchScore>();
    }

    public Game Game { get;  }
    public List<MatchScore> Scores { get; set; }
}