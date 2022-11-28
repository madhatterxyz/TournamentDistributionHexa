
using TournamentDistributionHexa.Domain.Scores;
using TournamentDistributionHexa.Infrastructure.Models;

namespace TournamentDistributionHexa.Infrastructure.Mappers
{
    public static class ScoreMapper
    {
        public static Score Map(ScoreDTO scoreDTO)
        {
            return new Score() {JoueurId = scoreDTO.JoueurId, MatchId = scoreDTO.MatchId, Points = scoreDTO.Points};
        }

        public static ScoreDTO Map(Score score)
        {
            return new ScoreDTO(score.MatchId, score.JoueurId, score.Points??0);
        }
    }
}
