using TournamentDistributionHexa.Domain.Teams;

namespace TournamentDistributionHexa.Domain.Games;

public record Game
{
    public Game(int id, string name)
    {
        ID = id;
        Name = name;
        Teams = new List<Team>();
    }
    public int ID { get; }
    public string Name { get; }
    public List<Team> Teams { get; set; }
}