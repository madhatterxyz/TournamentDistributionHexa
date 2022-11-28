using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentDistributionHexa.Domain.Scores;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Pages.Scores
{
    public class EditModel : PageModel
    {
        private readonly IScoreServices _services;

        public EditModel(IScoreServices services)
        {
            _services = services;
        }

        [BindProperty]
        public ScoreDTO Score { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long matchId, long joueurId)
        {
            Score = await _services.GetById(matchId, joueurId);
            if (Score == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _services.Update(Score);

            return RedirectToPage("/Tournois/Index");
        }
    }
}
