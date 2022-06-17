namespace SoccerTournament.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Mapping;
    using SoccerTournament.Models.Player;
    using SoccerTournament.Models.Team;

    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext db;

        public TeamService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Team> CreateTeamAsync(TeamFormModel model)
        {
            var country = await this.db.Countries.FirstOrDefaultAsync(x => x.Name == model.Country);
            if (country == null)
            {
                 country = new Country
                {
                    Name = model.Country,
                };
            }
            var coach = await this.db.Coaches.FirstOrDefaultAsync(x => x.Id == model.CoachId);
            
            var team = new Team
            {
                Name = model.Name,
                Emblem=model.Emblem,
                CoachId = model.CoachId,
                Coach=coach,
                Country = country,
            };
            coach.TeamId= team.Id;
            foreach (var player in model.PlayersSelectList)
            {
                Player pl = await this.db.Players.FirstOrDefaultAsync(x => x.Id == player);
                if (pl != null)
                {
                    team.Players.Add(pl);
                    pl.TeamId = team.Id;
                }
            }

            await this.db.Teams.AddAsync(team);
            await this.db.SaveChangesAsync();
            return team;
        }



        public async Task<ICollection<T>> GetAllTeamsByIdAsync<T>(int page, int itemsPerPage = 12)
        {
            return await this.db.Teams
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var player = await this.db.Teams.FirstOrDefaultAsync(x => x.Id == id);
           
            var coach = db.Coaches.FirstOrDefault(c => c.TeamId == id);
            if (coach != null)
            {
                coach.TeamId = null;
            }
          
            db.Teams.Remove(player);
            await db.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var team = await this.db.Teams
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            if (team == null)
            {
                throw new NullReferenceException(string.Format("Team not found", id));
            }
            return team;
        }
    }
}
