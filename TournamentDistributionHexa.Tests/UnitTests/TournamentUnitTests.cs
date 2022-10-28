using Microsoft.Extensions.Configuration;
using Moq;
using TournamentDistributionHexa.Domain;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Tests.UnitTests
{
    public class TournamentUnitTests
    {
        [Fact]
        public void CreateTournoi_Should_Return_10Matchs()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = new List<Player>() { GetPlayers()[0], GetPlayers()[1], GetPlayers()[2] };
            List<Game> games = GetGames();

            //Act
            List<TournamentMatch> matchs = domain.Create(players, games);

            //Assert
            Assert.True(matchs.Select(x => x.Game).Distinct().Count() == 10);
        }
        [Fact]
        public void CreateTournoi_Should_Return_1Matchs_Per_Game()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = new List<Player>() { GetPlayers()[0], GetPlayers()[1], GetPlayers()[2] };
            List<Game> games = GetGames();
            List<TournamentMatch> expectedMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = games[0] },
                new TournamentMatch(){ Game = games[1] },
                new TournamentMatch(){ Game = games[2] },
                new TournamentMatch(){ Game = games[3] },
                new TournamentMatch(){ Game = games[4] },
                new TournamentMatch(){ Game = games[5] },
                new TournamentMatch(){ Game = games[6] },
                new TournamentMatch(){ Game = games[7] },
                new TournamentMatch(){ Game = games[8] },
                new TournamentMatch(){ Game = games[9] },
            };
            //Act
            List<TournamentMatch> matchs = domain.Create(players, games);
            //Assert
            Assert.True(expectedMatchs.Select(x => x.Game).Distinct().SequenceEqual(matchs.Select(x => x.Game).Distinct()));
        }
        [Fact]
        public void CreateTournoi_With1Game_Should_Return_3DifferentPlayers_Per_Match()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = GetPlayers();
            List<Game> games = new List<Game>()
            {
                new Game(){ ID = 1, Name = "Ark Nova"}
            };
            List<TournamentMatch> expectedMatchs = new List<TournamentMatch>()
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
            List<TournamentMatch> matchs = domain.Create(players, games);
            //Assert
            Assert.True(expectedMatchs.SequenceEqual(matchs));
        }

        [Fact]
        public async Task GetAll_Should_Return_1_TournamentMatch()
        {
            //Arrange
            var adapter = new Mock<ITournamentRepository>();
            adapter.Setup(x => x.GetAll()).Returns(new List<TournamentMatch>() {
                new TournamentMatch() {
                    Game = GetGames()[0],
                    Scores = new List<MatchScore>(){
                        new MatchScore()
                        {
                            Player = GetPlayers()[0]
                        }
                    }
                }
            });
            ITournamentDomain domain = GetDomain(adapter.Object);
            //Act
            List<TournamentMatch> matchs = await domain.GetAll();
            //Assert
            Assert.True(matchs.Count() == 1);
        }
        [Fact]
        public void GetNumberOfOccurence_Should_Return_1_for_Player1()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = GetPlayers();
            Game game = GetGames()[0];
            List<TournamentMatch> tournamentMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[0] },
                    new MatchScore() { Player = players[1] },
                    new MatchScore() { Player = players[2] },
                } },
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[3] },
                    new MatchScore() { Player = players[4] },
                    new MatchScore() { Player = players[5] },
                } },
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[6] },
                    new MatchScore() { Player = players[7] },
                    new MatchScore() { Player = players[8] },
                } },
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[9] },
                    new MatchScore() { Player = players[10] },
                    new MatchScore() { Player = players[11] },
                } }

            };

            //Act
            int numberOfOccurence = domain.GetNumberOfOccurence(players[0], tournamentMatchs);

            //Assert
            Assert.True(numberOfOccurence == 1);
        }
        [Fact]
        public void GetNumberOfOccurencesOfPlayers_Should_Return_1_for_each_Player()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = GetPlayers();
            Game game = GetGames()[0];
            List<TournamentMatch> tournamentMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[0] },
                    new MatchScore() { Player = players[1] },
                    new MatchScore() { Player = players[2] },
                } },
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[3] },
                    new MatchScore() { Player = players[4] },
                    new MatchScore() { Player = players[5] },
                } },
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[6] },
                    new MatchScore() { Player = players[7] },
                    new MatchScore() { Player = players[8] },
                } },
                new TournamentMatch(){ Game = game, Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[9] },
                    new MatchScore() { Player = players[10] },
                    new MatchScore() { Player = players[11] },
                } }

            };
            Dictionary<Player, int> expectedResult = new Dictionary<Player, int>()
            {
                {players[0],1 },
                {players[1],1 },
                {players[2],1 },
                {players[3],1 },
                {players[4],1 },
                {players[5],1 },
                {players[6],1 },
                {players[7],1 },
                {players[8],1 },
                {players[9],1 },
                {players[10],1 },
                {players[11],1 }
            };

            //Act
            Dictionary<Player, int> numberOfOccurences = domain.GetNumberOfOccurenceOfPlayers(players, tournamentMatchs);

            //Assert
            Assert.True(numberOfOccurences.SequenceEqual(expectedResult));
        }

        [Fact]
        public void GetNumberOfOccurencesOfPlayers_Should_Return_2_for_each_Player()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = GetPlayers();
            List<Game> games = new List<Game>() { GetGames()[0], GetGames()[1] };
            List<TournamentMatch> tournamentMatchs = new List<TournamentMatch>()
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
                } },
                new TournamentMatch(){ Game = games[1], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[0] },
                    new MatchScore() { Player = players[1] },
                    new MatchScore() { Player = players[2] },
                } },
                new TournamentMatch(){ Game = games[1], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[3] },
                    new MatchScore() { Player = players[4] },
                    new MatchScore() { Player = players[5] },
                } },
                new TournamentMatch(){ Game = games[1], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[6] },
                    new MatchScore() { Player = players[7] },
                    new MatchScore() { Player = players[8] },
                } },
                new TournamentMatch(){ Game = games[1], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[9] },
                    new MatchScore() { Player = players[10] },
                    new MatchScore() { Player = players[11] },
                } }

            };
            Dictionary<Player, int> expectedResult = new Dictionary<Player, int>()
            {
                {players[0],2 },
                {players[1],2 },
                {players[2],2 },
                {players[3],2 },
                {players[4],2 },
                {players[5],2 },
                {players[6],2 },
                {players[7],2 },
                {players[8],2 },
                {players[9],2 },
                {players[10],2 },
                {players[11],2 }
            };

            //Act
            Dictionary<Player, int> numberOfOccurences = domain.GetNumberOfOccurenceOfPlayers(players, tournamentMatchs);

            //Assert
            Assert.True(numberOfOccurences.SequenceEqual(expectedResult));
        }

        [Fact]
        public void CreateTournoi_With_10_Games_And_12_Players_Should_Have_1_Meeting_Per_Player_Pairing()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = GetPlayers();
            List<Game> games = GetGames();

            int[][] MemberPairing = new int[players.Count][];
            for (int i = 0; i < players.Count; i++)
                MemberPairing[i] = new int[players.Count];

            //Act
            List<Game> Games = domain.GetEvenlyDistributedGames(games.Count, players.Count);

            foreach (Game Game in Games)
                foreach (var Team in Game.Teams)
                    foreach (int Member in Team.Players)
                        foreach (int OtherMember in Team.Players)
                            if (Member != OtherMember)
                                MemberPairing[Member][OtherMember]++;

            //Assert
            for (int i = 0; i < players.Count; i++)
                for (int j = 0; j < players.Count; j++)
                {
                    int PairingCount = MemberPairing[i][j];
                    Assert.True(i == j || PairingCount > 0);
                }
        }

        private ITournamentDomain GetDomain()
        {
            var adapter = new Mock<ITournamentRepository>();
            return new TournamentDomain(adapter.Object, GetConfiguration());
        }
        private ITournamentDomain GetDomain(ITournamentRepository adapter)
        {
            return new TournamentDomain(adapter, GetConfiguration());
        }
        private IConfiguration GetConfiguration()
        {
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["AppSettings:NumberOfPlayersByTeam"]).Returns("3");
            return configuration.Object;
        }
        private List<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player(){ID=1, Firstname = "Nicolas",Lastname="B",Telephone=""},
                new Player(){ID=2, Firstname = "Alexandra",Lastname="F",Telephone=""},
                new Player(){ID=3, Firstname = "Jeremy",Lastname="F",Telephone=""},
                new Player(){ID=4, Firstname = "Ludovic",Lastname="R",Telephone=""},
                new Player(){ID=5, Firstname = "Julien",Lastname="P",Telephone=""},
                new Player(){ID=6, Firstname = "Nicolas",Lastname="F",Telephone=""},
                new Player(){ID=7, Firstname = "Corentin",Lastname="C",Telephone=""},
                new Player(){ID=8, Firstname = "Corinne",Lastname="O",Telephone=""},
                new Player(){ID=9, Firstname = "Laura",Lastname="X",Telephone=""},
                new Player(){ID=10, Firstname = "Noémie",Lastname="R",Telephone=""},
                new Player(){ID=11, Firstname = "Denis",Lastname="R",Telephone=""},
                new Player(){ID=12, Firstname = "Gabriel",Lastname="Y",Telephone=""}
            };
        }
        private List<Game> GetGames()
        {
            return new List<Game>()
            {
                new Game(){ ID = 1, Name = "Ark Nova"},
                new Game(){ ID = 2, Name = "Zombidice"},
                new Game(){ ID = 3, Name = "Perudo"},
                new Game(){ ID = 4, Name = "Living Forest"},
                new Game(){ ID = 5, Name = "Mille fiori"},
                new Game(){ ID = 6, Name = "Augustus"},
                new Game(){ ID = 7, Name = "Dune Imperium"},
                new Game(){ ID = 8, Name = "Cactus town"},
                new Game(){ ID = 9, Name = "Akropolis"},
                new Game(){ ID = 10, Name = "L'âge de pierre"}
            };
        }

    }

}