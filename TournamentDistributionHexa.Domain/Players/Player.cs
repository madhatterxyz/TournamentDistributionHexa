namespace TournamentDistributionHexa.Domain.Players;

public record Player
{
    public Player(int id, string firstname, string lastname, string telephone)
    {
        ID = id;
        Firstname = firstname;
        Lastname = lastname;
        Telephone = telephone;
    }
    public int ID { get; }
    public string Firstname { get; }
    public string Lastname { get; }
    public string Telephone { get; }
}