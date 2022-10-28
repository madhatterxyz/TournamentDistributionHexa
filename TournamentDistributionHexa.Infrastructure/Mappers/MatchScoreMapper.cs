using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Infrastructure.Models;

namespace TournamentDistributionHexa.Infrastructure.Mappers
{
    public static class MatchScoreMapper
    {
        public static MatchScore GetMatchScore(Score score)
        {
            return new MatchScore(new Player()
            {
                ID = (int)score.JoueurId,
                Firstname = score.Joueur.Prénom,
                Lastname = score.Joueur.Nom,
                Telephone = score.Joueur.Telephone
            });
        }
    }
}
