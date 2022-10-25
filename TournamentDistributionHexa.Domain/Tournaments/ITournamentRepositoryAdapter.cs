using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Tournaments
{
    public interface ITournamentRepositoryAdapter
    {
        void Create(List<TournamentMatch> list);
    }
}
