namespace SoccerTournament.Models.Team
{
    public class TeamListViewModel
    {
        public IEnumerable<TeamInLIstViewModel> Teams { get; set; } = new List<TeamInLIstViewModel>();
    }
}
