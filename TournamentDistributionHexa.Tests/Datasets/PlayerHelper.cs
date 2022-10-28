using TournamentDistributionHexa.Domain.Players;

namespace TournamentDistributionHexa.Tests.Datasets
{
    public static class PlayerHelper
    {
        public static List<Player> GetPlayers()
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
        public static Player Get1Player()
        {
            return GetPlayers()[0];
        }
        public static List<Player> Get3Players()
        {
            return new List<Player>() { GetPlayers()[0], GetPlayers()[1], GetPlayers()[2] };
        }
    }
}
