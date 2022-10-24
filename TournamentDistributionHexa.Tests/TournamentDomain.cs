using System.Runtime.InteropServices;

namespace TournamentDistributionHexa.Tests
{
    public class TournamentDomain
    {
        public List<TournamentMatch> Create(List<Game> games)
        {
            var list = new List<TournamentMatch>();
            foreach (var game in games)
            {
                list.Add(new TournamentMatch() { Game = game });
            }
            return list;
        }
    }
}