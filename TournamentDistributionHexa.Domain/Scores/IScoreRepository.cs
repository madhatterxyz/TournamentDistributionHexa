using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Domain.Scores;

public interface IScoreRepository
{
    Task<ScoreDTO> Create(ScoreDTO score);
    Task<ScoreDTO> Update(ScoreDTO score);
}
