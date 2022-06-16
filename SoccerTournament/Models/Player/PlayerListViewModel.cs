namespace SoccerTournament.Models.Player
{
    public class PlayerListViewModel:PagingViewModel
    {
        public IEnumerable<PlayerInListViewModel> Players { get; set; } = new List<PlayerInListViewModel>();
    }
}
