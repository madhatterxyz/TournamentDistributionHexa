using MediatR;
using TournamentDistributionHexa.Application.Tournaments.Commands;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Tournaments.Handlers
{
    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, IEnumerable<TournamentMatch>>
    {
        private readonly ITournamentDomain _tournamentDomain;

        public CreateTournamentCommandHandler(ITournamentDomain tournamentDomain)
        {
            _tournamentDomain = tournamentDomain;
        }

        public async Task<IEnumerable<TournamentMatch>> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            return _tournamentDomain.Create(request.Name, request.Players, request.Games);
        }
    }
}
