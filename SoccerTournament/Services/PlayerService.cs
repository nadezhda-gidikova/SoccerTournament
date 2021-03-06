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
                AverageRating = model.AverageRating,
                RedCards = model.RedCards,
                Takle = model.Takle,
                YellowCards = model.YellowCards,
            };
            if(model.TeamId!=null)
            {
                player.TeamId = model.TeamId;
            }
            db.Players.Add(player);
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

        public async Task<ICollection<T>> GetAllPlayersBYFirstNameAsync<T>(int page, int itemsPerPage = 12)
        {
            return await this.db.Players
                .OrderBy(x => x.FirstName)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        }


        public async Task<ICollection<T>> GetAllPlayersByLastNameAsync<T>(int page, int itemsPerPage = 12)
        {
            return await this.db.Players
                .OrderBy(x => x.FamilyName)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
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
            if (player == null)
            {
                throw new NullReferenceException(string.Format("Player not found", id));
            }
            return player;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var book = await this.db.Players
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            if (book == null)
            {
                throw new NullReferenceException(string.Format("Player not found", id));
            }
            return book;
        }

        public async Task<ICollection<T>> GetPlayersKeyValueAsync<T>()
        {
            var players = await this.db
                .Players
                .To<T>()
                .ToListAsync();
            return players;
        }


    }
}
