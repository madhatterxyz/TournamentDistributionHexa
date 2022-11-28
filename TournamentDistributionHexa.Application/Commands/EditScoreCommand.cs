using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Application.Commands
{
    public class EditScoreCommand : IRequest<ScoreDTO>
    {
        public long MatchId { get;}
        public long JoueurId { get; }
        public int Points { get; }
        public EditScoreCommand(EditScoreRequest request)
        {
            MatchId = request.MatchId;
            JoueurId = request.JoueurId;
            Points = request.Points;
        }
    }
}
