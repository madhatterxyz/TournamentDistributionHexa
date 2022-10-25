namespace TournamentDistributionHexa.Tests
{
    public class TournamentMatch
    {
        public Game Game { get; set; }
        public List<MatchScore> Scores { get; set; }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(TournamentMatch)) return false;
            TournamentMatch other = (TournamentMatch)obj;

            return other.Game.Equals(this.Game) && other.Scores.SequenceEqual(this.Scores);
        }
    }
}