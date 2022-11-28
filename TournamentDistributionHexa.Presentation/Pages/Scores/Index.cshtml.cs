using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Pages.Scores;

public class IndexModel : PageModel
{
    private readonly IScoreServices _services;

    public IndexModel(IScoreServices services)
    {
        _services = services;
    }

    public IList<GetScoreResponse> Scores { get; set; } = default!;

    public async Task OnGet(long tournamentId)
    {
        Scores = await _services.GetScores(tournamentId);
    }
}
