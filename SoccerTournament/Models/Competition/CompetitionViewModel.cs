namespace SoccerTournament.Models.Competition
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Game;

    public class CompetitionViewModel:IMapFrom<Competition>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WinnerName { get; set; }

        public string MyProperty { get; set; }

        public ICollection<GameViewModel> Games { get; set; } = new List<GameViewModel>();
    }
}
