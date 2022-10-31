using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Models;
using TournamentDistributionHexa.Infrastructure.Repositories;

namespace TournamentDistributionHexa.Tests.IntegrationTests
{
    public class TournamentIntegrationTests
    {

        [Fact]
        public void CreateTournanement_With1Game_Should_Persist_1Tournoi()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<RepartitionTournoiContext>()
            .UseInMemoryDatabase(databaseName: "RepartitionTournoi")
            .Options;
            InitializeInMemoryDatabaseData(options);
            using (var _context = new RepartitionTournoiContext(options))
            {
                ITournamentMatchRepository domain = new TournamentMatchRepositoryAdapter(_context);
                List<Player> players = PlayerHelper.GetPlayers();
                List<Game> games = new List<Game>() { GameHelper.Get1Game() };
                List<TournamentMatch> matchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[0] },
                    new MatchScore() { Player = players[1] },
                    new MatchScore() { Player = players[2] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[3] },
                    new MatchScore() { Player = players[4] },
                    new MatchScore() { Player = players[5] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[6] },
                    new MatchScore() { Player = players[7] },
                    new MatchScore() { Player = players[8] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[9] },
                    new MatchScore() { Player = players[10] },
                    new MatchScore() { Player = players[11] },
                } }

            };
                //Act
                domain.Create(matchs);

                //Assert
                Assert.True(_context.Tournois.Count() == 1);
                Assert.True(_context.Tournois.FirstOrDefault().Compositions.Count() == 4);
                Assert.True(_context.Tournois.FirstOrDefault().Compositions.SelectMany(x => x.Match.Scores).Count() == 12);
            }
        }

        private static void InitializeInMemoryDatabaseData(DbContextOptions<RepartitionTournoiContext> options)
        {
            // Insert seed data into the database using one instance of the context
            using (var context = new RepartitionTournoiContext(options))
            {
                context.Joueurs.Add(new Joueur() { Id = 1, Prénom = "Nicolas", Nom = "B", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 2, Prénom = "Alexandra", Nom = "F", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 3, Prénom = "Jeremy", Nom = "F", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 4, Prénom = "Ludovic", Nom = "R", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 5, Prénom = "Julien", Nom = "P", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 6, Prénom = "Nicolas", Nom = "F", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 7, Prénom = "Corentin", Nom = "C", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 8, Prénom = "Corinne", Nom = "O", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 9, Prénom = "Laura", Nom = "X", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 10, Prénom = "Noémie", Nom = "R", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 11, Prénom = "Denis", Nom = "R", Telephone = "" });
                context.Joueurs.Add(new Joueur() { Id = 12, Prénom = "Gabriel", Nom = "Y", Telephone = "" });


                context.Jeus.Add(new Jeu() { Id = 1, Nom = "Ark Nova" });
                context.Jeus.Add(new Jeu() { Id = 2, Nom = "Zombidice" });
                context.Jeus.Add(new Jeu() { Id = 3, Nom = "Perudo" });
                context.Jeus.Add(new Jeu() { Id = 4, Nom = "Living Forest" });
                context.Jeus.Add(new Jeu() { Id = 5, Nom = "Mille fiori" });
                context.Jeus.Add(new Jeu() { Id = 6, Nom = "Augustus" });
                context.Jeus.Add(new Jeu() { Id = 7, Nom = "Dune Imperium" });
                context.Jeus.Add(new Jeu() { Id = 8, Nom = "Cactus town" });
                context.Jeus.Add(new Jeu() { Id = 9, Nom = "Akropolis" });
                context.Jeus.Add(new Jeu() { Id = 10, Nom = "L'âge de pierre" });
                context.SaveChanges();
            }
        }
    }

}