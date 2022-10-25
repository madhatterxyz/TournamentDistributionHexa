using TournamentDistributionHexa.Domain.Score;

namespace TournamentDistributionHexa.Domain.Tournament
{
    public class TournamentMatch
    {
        public Game Game { get; set; }
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