namespace SoccerTournament.Services
{
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Team;

    public interface ITeamService
    {
        public Task<Team> CreateTeamAsync(TeamFormModel model);



        public Task<ICollection<T>> GetAllTeamsByIdAsync<T>(int page, int itemsPerPage = 12);

    }
}
