using MediatR;
using System.Reflection;
using TournamentDistributionHexa.Application.Tournaments.Handlers;
using TournamentDistributionHexa.Application.Tournaments.Queries;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Configuration
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRequestHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly())
                .AddSingleton<IRequestHandler<GetAllTournamentsQuery, IEnumerable<Tournoi>>,GetAllTournamentQueryHandler>();

        }
    }
}
