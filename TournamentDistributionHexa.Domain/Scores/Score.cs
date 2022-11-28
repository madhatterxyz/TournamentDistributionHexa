namespace TournamentDistributionHexa.Domain.Scores;

public class ScoreDTO
{
    public ScoreDTO()
    {

    }
    public ScoreDTO(long matchId, long joueurId, int points)
    {
        MatchId = matchId;
        JoueurId = joueurId;
        Points = points;
    }

    public long MatchId { get; set; }
    public long JoueurId { get; set; }
    public int Points { get; set; }

}
