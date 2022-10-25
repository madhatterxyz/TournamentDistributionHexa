namespace TournamentDistributionHexa.Domain.Players
{
    public class Player
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Telephone { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Player)) return false;
            Player other = (Player)obj;
            return other.ID.Equals(ID) && other.Firstname.Equals(Firstname) && other.Lastname.Equals(Lastname) && other.Telephone.Equals(Telephone);
        }
    }
}