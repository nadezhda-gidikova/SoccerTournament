namespace SoccerTournament.Services
{
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Game;

    public interface IGameService
    {
        public Task<Game> CreateTeamAsync(GameFormModel model);

        public Task<ICollection<T>> GetAllByIdAsync<T>(int page, int itemsPerPage = 12);

        public Task<T> GetByIdAsync<T>(int id);

        public Task<ICollection<T>> GetAllByIdInListAsync<T>();

      
    }
}
