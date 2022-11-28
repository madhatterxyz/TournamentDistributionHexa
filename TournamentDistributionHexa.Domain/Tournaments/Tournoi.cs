using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Score;

namespace TournamentDistributionHexa.Domain.Tournament;

public record Tournoi
{
    public Tournoi() 
    {
        Nom = String.Empty;
    }
    public Tournoi(long id, string name, DateTime? startDate, DateTime? endDate)
    {
        Id = id;
        Nom = name;
        DateDebut = startDate;
        DateFin = endDate;
    }

    public long Id { get; init; }
    public string Nom { get; init; }
    public DateTime? DateDebut { get; init; }
    public DateTime? DateFin { get; init; }
}