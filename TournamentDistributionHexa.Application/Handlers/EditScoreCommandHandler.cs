﻿using MediatR;
using TournamentDistributionHexa.Application.Commands;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Application.Handlers
{
    public class EditScoreCommandHandler : IRequestHandler<EditScoreCommand, ScoreDTO>
    {
        private readonly IScoreDomain _scoreDomain;

        public EditScoreCommandHandler(IScoreDomain scoreDomain)
        {
            _scoreDomain = scoreDomain;
        }

        public async Task<ScoreDTO> Handle(EditScoreCommand request, CancellationToken cancellationToken)
        {

            return await _scoreDomain.Update(new ScoreDTO(request.MatchId, request.JoueurId, request.Points));
        }
    }
}
