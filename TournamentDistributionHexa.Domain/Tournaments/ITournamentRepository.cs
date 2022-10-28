using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Tournaments
{
    public interface ITournamentRepository
    {
        List<TournamentMatch> Create(string nom, List<TournamentMatch> tournamentMatches);
        List<TournamentMatch> GetAll();
    }
}
