using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Tournaments
{
    public interface ITournamentRepository
    {
        void Create(List<TournamentMatch> list);
        List<TournamentMatch> GetAll();
    }
}
