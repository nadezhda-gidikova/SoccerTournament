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
            var team = new Team
            {
                Name = model.Name,
                CoachId = model.CoachId,
                Country = country,
            };
            foreach (var player in model.PlayersSelectList)
            {
                Player pl = await this.db.Players.FirstOrDefaultAsync(x => x.Id == player);
                if (pl != null)
                {
                    team.Players.Add(pl
                        );
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
    }
}
