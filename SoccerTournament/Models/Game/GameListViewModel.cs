namespace SoccerTournament.Models.Game
{
    public class GameListViewModel
    {
        public IEnumerable<GameInListViewModel> Games { get; set; } = new List<GameInListViewModel>();
    }
}
