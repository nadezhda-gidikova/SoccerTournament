namespace SoccerTournament.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Mapping;
    using SoccerTournament.Models.Competition;

    public class CompetitionService : ICompetitionService
    {
        private readonly ApplicationDbContext db;

        public CompetitionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Competition> CreateCompetitionAsync(CompetitionFormModel model)
        {
            var competition = new Competition
            {
                Name=model.Name,
            };
            await this.db.Competitions.AddAsync(competition);
            await this.db.SaveChangesAsync();

            return competition;

        }

        public async Task<int> AddGamesToCompetitions(int gameId,int competitionId)
        {
            var game=await this.db.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
            {
                throw new NullReferenceException(string.Format("Game not exist"));
            }
            var competition = await this.db.Competitions.FirstOrDefaultAsync(x => x.Id == competitionId);
            if (competition == null)
            {
                throw new NullReferenceException(string.Format("Competition not exist"));
            }
           competition.Games.Add(game);
            await this.db.SaveChangesAsync();
            return competition.Id;
        }

        public async Task<int> RemoveGamesFromCompetitions(int gameId, int competitionId)
        {
            var game = await this.db.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
            {
                throw new NullReferenceException(string.Format("Game not exist"));
            }
            var competition = await this.db.Competitions.FirstOrDefaultAsync(x => x.Id == competitionId);
            if (competition == null)
            {
                throw new NullReferenceException(string.Format("Competition not exist"));
            }
            competition.Games.Remove(game);
            await this.db.SaveChangesAsync();
            return competition.Id;

        }

        public async Task<ICollection<T>> GetAllByIdAsync<T>(int page, int itemsPerPage = 12)
        {
            return await this.db.Competitions
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var game = await this.db.Competitions
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            if (game == null)
            {
                throw new NullReferenceException(string.Format("Competition not found", id));
            }
            return game;
        }
    }
}
