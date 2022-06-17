namespace SoccerTournament.Models.Competition
{
    public class CompetitionListViewModel
    {
        public ICollection<CompetitionInListViewModel> Competitions { get; set; } = new List<CompetitionInListViewModel>();

    }
}
