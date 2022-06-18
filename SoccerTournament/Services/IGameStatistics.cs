namespace SoccerTournament.Services
{
    public interface IGameStatistics
    {
        public Task<T> GameWithMostGoals<T>();

        public Task<T> GameWithMostRedCards<T>();

        public Task<T> GameWithMostCorners<T>();

        public Task<T> GameWithMostOffSites<T>();

        public Task<T> PlayersWithMostGoals<T>();

        public Task<T> PlayersWithMostRedCards<T>();

        public Task<T> PlayersWithMostYellowCards<T>();

        public Task<T> PlayersWithMostAssistances<T>();

        public Task<T> PlayersWithBiggestRating<T>();
    }
}
