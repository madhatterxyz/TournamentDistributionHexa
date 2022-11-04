using System.ComponentModel.DataAnnotations;

namespace TournamentDistributionHexa.Application.Tournaments.Models
{
    public class EditTournamentRequest
    {
        public EditTournamentRequest()
        {

        }

        public long Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
    }
}
