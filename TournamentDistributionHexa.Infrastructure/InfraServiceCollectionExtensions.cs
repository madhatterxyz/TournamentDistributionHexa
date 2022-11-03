using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Models;
using TournamentDistributionHexa.Infrastructure.Repositories;

namespace TournamentDistributionHexa.Infrastructure
{
    public static class InfraServiceCollectionExtensions
    {
        public static IServiceCollection RegisterInfraServices(this IServiceCollection services)
        {
            services.AddScoped<ITournamentMatchRepository, TournamentMatchRepositoryAdapter>();
            services.AddDbContext<RepartitionTournoiContext>(
                options => options.UseSqlServer("name=ConnectionStrings:RepartitionTournoiContext"));

            return services;
        }
    }
}
