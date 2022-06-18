namespace SoccerTournament.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data;
    using SoccerTournament.Mapping;

    public class GameSatistics:IGameStatistics
    {
        private readonly ApplicationDbContext db;

        public GameSatistics(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<T> GameWithMostGoals<T>()
        {
            return await this.db.Games.
                OrderByDescending(x=>x.Goals)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> GameWithMostRedCards<T>()
        {
            return await this.db.Games.
                OrderByDescending(x => x.RedCards)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> GameWithMostCorners<T>()
        {
            return await this.db.Games.
                OrderByDescending(x => x.Corners)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> GameWithMostOffSites<T>()
        {
            return await this.db.Games.
                OrderByDescending(x => x.OffSites)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> PlayersWithMostGoals<T>()
        {
            return await this.db.Players
                .OrderByDescending(x => x.Goals)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> PlayersWithMostRedCards<T>()
        {
            return await this.db.Players
                .OrderByDescending(x => x.RedCards)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> PlayersWithMostYellowCards<T>()
        {
            return await this.db.Players
                .OrderByDescending(x => x.YellowCards)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> PlayersWithMostAssistances<T>()
        {
            return await this.db.Players
                .OrderByDescending(x => x.Assistances)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> PlayersWithBiggestRating<T>()
        {
            return await this.db.Players
                .OrderByDescending(x => x.AverageRating)
                .To<T>()
                .FirstOrDefaultAsync();
        }
    }
}
