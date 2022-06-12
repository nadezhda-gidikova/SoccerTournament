namespace SoccerTournament.Services
{
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Player;

    public interface IPlayerService
    {
        public Task<Player> CreatePlayerAsync(PlayerFormModel model);

        public Task<ICollection<T>> GetAllPlayersByTeamAsync<T>(string teamName);

        public Task<Player> GetPlayerByIdAsinc(int id);

    }
}
