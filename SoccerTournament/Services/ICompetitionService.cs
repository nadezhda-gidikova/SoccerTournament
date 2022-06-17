namespace SoccerTournament.Services
{
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Competition;

    public interface ICompetitionService
    {
        public Task<Competition> CreateCompetitionAsync(CompetitionFormModel model);

        public Task<int> AddGamesToCompetitions(int gameId, int competitionId);

        public Task<int> RemoveGamesFromCompetitions(int gameId, int competitionId);

        public Task<ICollection<T>> GetAllByIdAsync<T>(int page, int itemsPerPage = 12);

        public Task<T> GetByIdAsync<T>(int id);
    }
}
