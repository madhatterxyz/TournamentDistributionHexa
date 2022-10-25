namespace TournamentDistributionHexa.Tests
{
    public class MatchScore
    {
        public Player Player { get; set; }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(MatchScore)) return false;   
            MatchScore other = (MatchScore)obj;
            return other.Player.Equals(this.Player);
        }
    }
}