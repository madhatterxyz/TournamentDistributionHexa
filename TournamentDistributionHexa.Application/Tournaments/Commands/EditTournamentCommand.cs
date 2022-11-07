using MediatR;
using TournamentDistributionHexa.Application.Tournaments.Models;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Tournaments.Commands
{
    public class EditTournamentCommand : IRequest<Tournoi>
    {
        public long Id { get;}
        public string Name { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public EditTournamentCommand(EditTournamentRequest request)
        {
            Id = request.Id;
            Name = request.Nom;
            StartDate = request.DateDebut;
            EndDate = request.DateFin;
        }
    }
}
