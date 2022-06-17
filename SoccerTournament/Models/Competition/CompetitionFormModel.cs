namespace SoccerTournament.Models.Competition
{
    using SoccerTournament.Models.Game;
    using SoccerTournament.Models.Team;
    using System.ComponentModel.DataAnnotations;

    public class CompetitionFormModel
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<TeamViewModel> Teams { get; set; } = new HashSet<TeamViewModel>();

        public ICollection<GameViewModel> Games { get; set; } = new HashSet<GameViewModel>();

        public virtual ICollection<int> GamesSelectList { get; set; } = new HashSet<int>();
    }
}
