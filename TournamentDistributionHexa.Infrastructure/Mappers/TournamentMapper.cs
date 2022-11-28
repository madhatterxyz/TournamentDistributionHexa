namespace TournamentDistributionHexa.Infrastructure.Mappers
{
    public static class TournamentMapper
    {
        public static Domain.Tournament.Tournoi GetTournament(Models.Tournoi tournoi)
        {
            return new Domain.Tournament.Tournoi((int)tournoi.Id, tournoi.Nom, tournoi.DateDebut, tournoi.DateFin);
        }
    }
}
