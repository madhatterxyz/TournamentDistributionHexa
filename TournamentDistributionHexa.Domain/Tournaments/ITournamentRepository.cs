using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Tournaments
{
    public interface ITournamentRepository
    {
        List<TournamentMatch> Create(string nom, IList<TournamentMatch> tournamentMatches);
        List<TournamentMatch> GetAll();
    }
}
