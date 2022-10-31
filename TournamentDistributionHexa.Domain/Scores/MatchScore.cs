using TournamentDistributionHexa.Domain.Players;

namespace TournamentDistributionHexa.Domain.Score;

public record MatchScore
{
    public MatchScore(Player player)
    {
        Player = player;
    }
    public int Score { get; set; }
    public Player Player { get; }
}