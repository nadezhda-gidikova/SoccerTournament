namespace SoccerTournament.Services
{
    public interface ICoachService
    {
        public Task<T> GetByIdAsync<T>(int id);

        public Task<ICollection<T>> GetCoachesKeyValueAsync<T>();
    }
}
