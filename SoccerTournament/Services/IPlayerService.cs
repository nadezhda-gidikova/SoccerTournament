namespace SoccerTournament.Services
{
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Player;

    public interface IPlayerService
    {
        public Task<Player> CreatePlayerAsync(PlayerFormModel model);

        public Task<ICollection<T>> GetAllPlayersByTeamAsync<T>(string teamName);

        public Task<T> GetByIdAsync<T>(int id);

        public Task<ICollection<T>> GetAllPlayersBYFirstNameAsync<T>(int page, int itemsPerPage = 12);

        public Task<ICollection<T>> GetAllPlayersByLastNameAsync<T>(int page, int itemsPerPage = 12);

        public Task DeletePlayerByIdAsync(int id);

        public Task<ICollection<T>> GetPlayersKeyValueAsync<T>();
    }
}
