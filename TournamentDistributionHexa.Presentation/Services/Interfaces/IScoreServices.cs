using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

public interface IScoreServices
{
    Task<List<GetScoreResponse>> GetScores(long tournamentId);
    Task<ScoreDTO> GetById(long matchId, long joueurId);
    Task Update(ScoreDTO scoreDTO);
}
