namespace SoccerTournament.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Mapping;
    using SoccerTournament.Models.Player;
    using System.Threading.Tasks;

    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext db;

        public PlayerService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Player> CreatePlayerAsync(PlayerFormModel model)
        {
            var player = new Player
            {
                FirstName = model.FirstName,
                FamilyName = model.FamilyName,
                DateOfBirth = model.DateOfBirth,
                Position = (Position)Enum.Parse(typeof(Position), model.Position),
                PictureUrl=model.PictureUrl,
                Number = model.Number,
                Goals = model.Goals,
                Assistances = model.Assistances,
                TeamId = model.TeamId,
                AverageRating = model.AverageRating,
                RedCards = model.RedCards,
                Takle = model.Takle,
                YellowCards = model.YellowCards,
            };
            db.Add(player);
           await db.SaveChangesAsync();

            return player;
        }

        public async Task<ICollection<T>> GetAllPlayersByTeamAsync<T>(string teamName)
        {
            return await this.db.Players
                .Where(x=>x.Team.Name == teamName)
                .OrderBy(x => x.FirstName)
                .To<T>()
                .ToListAsync();
        }

        public async Task DeletePlayerByIdAsync(int id)
        {
            var player = await this.db.Players.FirstOrDefaultAsync(x => x.Id == id);
            db.Players.Remove(player);
            await db.SaveChangesAsync();
        }

        public async Task DeletePlayerByNameAsync(string playerFirstName, string playerFamilyName)
        {
            var player =await this.db.Players.FirstOrDefaultAsync(x => x.FirstName == playerFirstName && x.FamilyName==playerFamilyName);
            db.Players.Remove(player);
            await db.SaveChangesAsync();
        }
        public async Task<Player> GetPlayerByIdAsinc(int id)
        {
            Player player = await this.db.Players.FirstOrDefaultAsync(x => x.Id == id);
            return player;
        }

    }
}
