using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain.Scores;
using TournamentDistributionHexa.Infrastructure.Mappers;
using TournamentDistributionHexa.Infrastructure.Models;

namespace TournamentDistributionHexa.Infrastructure.Repositories;

public class ScoreRepositoryAdapter : IScoreRepository
{
    private readonly RepartitionTournoiContext _dbContext;
    public ScoreRepositoryAdapter(RepartitionTournoiContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ScoreDTO> Create(ScoreDTO scoreDTO)
    {
        Score score = ScoreMapper.Map(scoreDTO);
        _dbContext.Scores.Add(score);
        await _dbContext.SaveChangesAsync();
        return ScoreMapper.Map(score);
    }


    public async Task<ScoreDTO> Update(ScoreDTO scoreDTO)
    {
        Score score = ScoreMapper.Map(scoreDTO);
        _dbContext.Attach(score).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return ScoreMapper.Map(score);
    }
}