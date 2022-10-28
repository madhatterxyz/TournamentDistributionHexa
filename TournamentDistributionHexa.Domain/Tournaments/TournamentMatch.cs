using TournamentDistributionHexa.Domain.Score;

namespace TournamentDistributionHexa.Domain.Tournament
{
    public class TournamentMatch
    {
        public TournamentMatch(Game game)
        {
            Game = game;
            Scores = new List<MatchScore>();
        }

        public Game Game { get;  }
        public List<MatchScore> Scores { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(TournamentMatch)) return false;
            TournamentMatch other = (TournamentMatch)obj;

            return other.Game.Equals(Game) && other.Scores.SequenceEqual(Scores);
        }
    }
}