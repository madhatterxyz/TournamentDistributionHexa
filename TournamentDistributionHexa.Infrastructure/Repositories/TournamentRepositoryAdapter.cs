using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Mappers;
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
        public List<TournamentMatch> Create(string nom, List<TournamentMatch> tournamentMatches)
        {
            Tournoi tournoi = new Tournoi()
            {
                Nom = nom
            };
            _context.Tournois.Add(tournoi);
            SaveMatchs(tournamentMatches, tournoi);
            _context.SaveChanges();
            return GetAll();
        }

        private void SaveMatchs(List<TournamentMatch> tournamentMatchs, Tournoi tournoi)
        {
            for (int i = 0; i < tournamentMatchs.Count; i++)
            {
                Match match = new Match() { Nom = $"Match {i}" };
                match.Scores = new List<Score>();
                List<int> joueurIds = GetJoueurIds(tournamentMatchs, i);
                foreach (int joueurId in joueurIds)
                {
                    match.Scores.Add(new Score() { JoueurId = joueurId });
                }
                _context.Matches.Add(match);
                SaveComposition(tournamentMatchs, tournoi, i, match);
            }
        }

        private List<int> GetJoueurIds(List<TournamentMatch> tournamentMatchs, int i)
        {
            return _context.Joueurs.Where(x => tournamentMatchs[i].Scores.Select(y => y.Player.ID).Contains((int)x.Id)).Select(x => (int)x.Id).ToList();
        }

        private void SaveComposition(List<TournamentMatch> tournamentMatchs, Tournoi tournoi, int i, Match match)
        {
            Composition composition = new Composition() { JeuId = tournamentMatchs[i].Game.ID, MatchId = match.Id, TournoiId = tournoi.Id };
            _context.Compositions.Add(composition);
        }

        public List<TournamentMatch> GetAll()
        {
            List<TournamentMatch> result = new List<TournamentMatch>();
            var tournois = _context.Tournois.SelectMany(x => x.Compositions).Include(x=>x.Jeu).Include(x=>x.Match).ThenInclude(x=>x.Scores).ThenInclude(x=>x.Joueur);
            foreach(var tournoi in tournois)
            {
                result.Add(GetTournamentMatch(tournoi));
            }
            return result;
        }

        private TournamentMatch GetTournamentMatch(Composition composition)
        {
            TournamentMatch tournamentMatch = new TournamentMatch(new Domain.Game() { ID = (int)composition.JeuId, Name = composition.Jeu.Nom });
            List<MatchScore> matchScores = new List<MatchScore>();
            foreach (var score in composition.Match.Scores)
            {
                matchScores.Add(MatchScoreMapper.GetMatchScore(score));
            }
            tournamentMatch.Scores = matchScores;
            return tournamentMatch;
        }
    }
}
