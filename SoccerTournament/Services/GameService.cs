namespace SoccerTournament.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Mapping;
    using SoccerTournament.Models.Game;

    public class GameService:IGameService
    {
        private readonly ApplicationDbContext db;

        public GameService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Game> CreateTeamAsync(GameFormModel model)
        {
            var referee = await this.db.Referees.FirstOrDefaultAsync(x => x.FullName == model.Referee);
            if (referee == null)
            {
                referee = new Referee
                {
                    FullName = model.Referee,
                };
            }
            //var coach = await this.db.Coaches.FirstOrDefaultAsync(x => x.Id == model.CoachId);
           
            var game = new Game
            {
              Referee = referee,
              RefereeId=referee.Id,
              HomeTeamId=model.HomeTeamId,
              AwayTeamId=model.AwayTeamId,
              HomeTeamGoals=model.HomeTeamGoals,
              AwayTeamGoals=model.AwayTeamGoals,
              Goals=model.HomeTeamGoals+model.AwayTeamGoals,
              Corners=model.Corners,
              BallPossessions=model.BallPossessions,
              OffSites=model.OffSites,
              ShotsOfTarget=model.ShotsOfTarget,
              ShotsOnTarget=model.ShotsOnTarget,
              Falls=model.Falls,
              YellowCards=model.YellowCards,
              RedCards=model.RedCards,
              Stage= (Stage)Enum.Parse(typeof(Stage), model.Stage),
                TrollIns =model.TrollIns,
                WinnnerTeamId=model.WinnnerTeamId,
            };
            var homeTeam = await this.db.Teams.FirstOrDefaultAsync(x => x.Id == model.HomeTeamId);
            var awaytTeam = await this.db.Teams.FirstOrDefaultAsync(x => x.Id == model.AwayTeamId);
            var winTeam = await this.db.Teams.FirstOrDefaultAsync(x => x.Id == model.WinnnerTeamId);

            if (homeTeam==null || awaytTeam==null || winTeam==null)
            {
                throw new NullReferenceException(string.Format("Team not found"));
            }
            if (winTeam !=homeTeam && winTeam !=awaytTeam)
            {
                throw new NullReferenceException(string.Format("Team can not win"));
            }
            string gameName=homeTeam.Name+" - "+awaytTeam.Name;
            game.Name = gameName;
            homeTeam.HomeGames.Add(game);
            awaytTeam.AwayGames.Add(game);
            winTeam.GamesWin.Add(game);
            
            await this.db.Games.AddAsync(game);
            await this.db.SaveChangesAsync();
            return game;
        }



        public async Task<ICollection<T>> GetAllByIdAsync<T>(int page, int itemsPerPage = 12)
        {
            return await this.db.Games
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        }

        public async Task<ICollection<T>> GetAllByIdInListAsync<T>()
        {
            return await this.db.Games
                .OrderBy(x => x.Name)
                .To<T>()
                .ToListAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var game = await this.db.Games.FirstOrDefaultAsync(x => x.Id == id);

            var coach = db.Coaches.FirstOrDefault(c => c.TeamId == id);
            if (coach != null)
            {
                coach.TeamId = null;
            }

            db.Games.Remove(game);
            await db.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var game = await this.db.Games
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            if (game == null)
            {
                throw new NullReferenceException(string.Format("Game not found", id));
            }
            return game;
        }
    }
}
