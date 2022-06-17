namespace SoccerTournament.Models.Competition
{
    using SoccerTournament.Models.Game;
    using SoccerTournament.Models.Team;

    public class CompetitionFormModel
    {
        public string Name { get; set; }

        public ICollection<TeamViewModel> Teams { get; set; } = new HashSet<TeamViewModel>();

        public ICollection<GameViewModel> Games { get; set; } = new HashSet<GameViewModel>();

    }
}
