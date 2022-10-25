using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
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
        public List<TournamentMatch> GetAll()
        {
            List<TournamentMatch> result = new List<TournamentMatch>();
            var tournois = _context.Tournois.SelectMany(x => x.Compositions).Include(x=>x.Jeu).Include(x=>x.Match).ThenInclude(x=>x.Scores).ThenInclude(x=>x.Joueur);
            foreach(var item in tournois)
            {
                TournamentMatch tournamentMatch = new TournamentMatch() { 
                    Game = new Domain.Game() { ID = (int)item.JeuId, Name = item.Jeu.Nom}};
                List<MatchScore> matchScores = new List<MatchScore>();
                foreach(var score in item.Match.Scores)
                {
                    MatchScore matchScore = new MatchScore()
                    {
                        Player = new Player()
                        {
                            ID = (int)score.JoueurId,
                            Firstname = score.Joueur.Prénom,
                            Lastname = score.Joueur.Nom,
                            Telephone = score.Joueur.Telephone
                        }
                    };
                    matchScores.Add(matchScore);
                }
                tournamentMatch.Scores = matchScores;
                result.Add(tournamentMatch);
            }
            return result;
        }
    }
}
