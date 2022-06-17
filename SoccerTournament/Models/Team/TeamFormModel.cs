namespace SoccerTournament.Models.Team
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Models.Coach;
    using SoccerTournament.Models.Player;
    using SoccerTournament.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class TeamFormModel:IMapFrom<Team>,IMapTo<Team>
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public string Emblem { get; set; }

        public int CoachId { get; set; }

        public string Country { get; set; }

        public ICollection<CoachViewModel> Coaches { get; set; } = new HashSet<CoachViewModel>();

        public virtual ICollection<PlayerViewModel> Players { get; set; } = new HashSet<PlayerViewModel>();

        public virtual ICollection<int> PlayersSelectList { get; set; } = new HashSet<int>();

    }
}
