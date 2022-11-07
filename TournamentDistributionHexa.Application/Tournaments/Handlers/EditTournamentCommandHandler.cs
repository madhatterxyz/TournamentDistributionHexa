using MediatR;
using TournamentDistributionHexa.Application.Tournaments.Commands;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Tournaments.Handlers
{
    public class EditTournamentCommandHandler : IRequestHandler<EditTournamentCommand, Tournoi>
    {
        private readonly ITournamentDomain _tournamentDomain;

        public EditTournamentCommandHandler(ITournamentDomain tournamentDomain)
        {
            _tournamentDomain = tournamentDomain;
        }

        public async Task<Tournoi> Handle(EditTournamentCommand request, CancellationToken cancellationToken)
        {

            return await _tournamentDomain.Update(request.Id, request.Name, (DateTime)request.StartDate, (DateTime)request.EndDate);
        }
    }
}
