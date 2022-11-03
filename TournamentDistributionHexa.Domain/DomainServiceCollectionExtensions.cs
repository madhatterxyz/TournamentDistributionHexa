﻿using Microsoft.Extensions.DependencyInjection;
using TournamentDistributionHexa.Domain.Repositories;

namespace TournamentDistributionHexa.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITournamentDomain, TournamentDomain>();
            return services;
        }
    }
}
