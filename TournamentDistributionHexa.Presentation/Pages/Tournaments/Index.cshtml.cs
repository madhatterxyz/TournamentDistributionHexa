using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Pages.Tournaments
{
    public class IndexModel : PageModel
    {
        private readonly ITournamentDomain _services;

        public IndexModel(ITournamentDomain services)
        {
            _services = services;
        }

        public IList<TournamentMatch> Tournois { get; set; } = default!;

        public void OnGet()
        {
            Tournois = _services.GetAll();
        }
    }
}
