namespace TournamentDistributionHexa.Tests
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Game)) return false;
            Game other = (Game)obj;

            return other.ID.Equals(this.ID) && other.Name.Equals(this.Name);
        }
    }
}