using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

public interface ITournamentServices
{
    Task<List<GetTournamentResponse>> All();
}
