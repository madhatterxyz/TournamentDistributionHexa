using MediatR;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Tournaments.Queries
{
    public class GetAllTournamentsQuery : IRequest<IEnumerable<Tournoi>>
    {
        public GetAllTournamentsQuery()
        {
        }
    }
}
