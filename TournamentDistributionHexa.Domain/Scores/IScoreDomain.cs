namespace TournamentDistributionHexa.Domain.Scores;

public interface IScoreDomain
{
    Task<ScoreDTO> Update(ScoreDTO score);
}
