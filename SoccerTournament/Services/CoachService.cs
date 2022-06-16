namespace SoccerTournament.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data;
    using SoccerTournament.Mapping;

    public class CoachService:ICoachService
    {
        private readonly ApplicationDbContext db;

        public CoachService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var book = await this.db.Coaches
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            if (book == null)
            {
                throw new NullReferenceException(string.Format("Coach not found", id));
            }
            return book;
        }
        public async Task<ICollection<T>> GetCoachesKeyValueAsync<T>()
        {
            var coaches = await this.db
                .Coaches
                .To<T>()
                .ToListAsync();
            return coaches;
        }
    }
}
