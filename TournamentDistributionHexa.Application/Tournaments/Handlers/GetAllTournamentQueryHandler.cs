using Dapper;
using MediatR;
using TournamentDistributionHexa.Application.Tournaments.Queries;
using TournamentDistributionHexa.Domain.Configuration.Data;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Application.Tournaments.Handlers
{
    public class GetAllTournamentQueryHandler : IRequestHandler<GetAllTournamentsQuery, IEnumerable<Tournoi>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllTournamentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<Tournoi>> Handle(GetAllTournamentsQuery request, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT " +
                               "t.[Id], " +
                               "t.[Nom], " +
                               "t.[DateDebut], " +
                               "t.[DateFin] " +
                               "FROM [dbo].[Tournoi] AS t ";
            return await connection.QueryAsync<Tournoi>(sql);
        }
    }
}
