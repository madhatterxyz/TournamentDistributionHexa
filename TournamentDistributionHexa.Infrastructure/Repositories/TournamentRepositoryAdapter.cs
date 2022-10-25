using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Models;

namespace TournamentDistributionHexa.Infrastructure.Repositories
{
    public class TournamentRepositoryAdapter : ITournamentRepository
    {
        private RepartitionTournoiContext _context;
        public TournamentRepositoryAdapter(RepartitionTournoiContext context)
        {
            _context = context;
        }
        public void Create(List<TournamentMatch> tournamentMatchs)
        {
            Tournoi tournoi = new Tournoi()
            {
                Nom = "2022-2023"
            };
            _context.Tournois.Add(tournoi);
            for(int i =0; i< tournamentMatchs.Count;i++)
            {
                Match match = new Match() { Nom = $"Match {i}" };
                _context.Matches.Add(match);
                foreach (var score in tournamentMatchs[i].Scores)
                {
                    Joueur joueur = _context.Joueurs.FirstOrDefault(x=>x.Id.Equals(score.Player.ID));
                    _context.Scores.Add(new Score() {JoueurId = joueur.Id, MatchId = match.Id  });
                }
                Composition composition = new Composition() { JeuId = tournamentMatchs[i].Game.ID, MatchId = match.Id, TournoiId = tournoi.Id };
                _context.Compositions.Add(composition);
            }
            _context.SaveChanges();
        }
    }
}
