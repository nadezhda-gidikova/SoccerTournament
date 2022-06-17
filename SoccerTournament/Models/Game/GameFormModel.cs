namespace SoccerTournament.Models.Game
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Team;
    using System.ComponentModel.DataAnnotations;

    public class GameFormModel:IMapFrom<Game>
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        [MaxLength(100)]
        public string Referee { get; set; }

        public int WinnnerTeamId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public string Stage { get; set; }

        [Range(0,2000)]
        public int YellowCards { get; set; }

        [Range(0, 2000)]
        public int RedCards { get; set; }

        [Range(0, 2000)]
        public int ShotsOnTarget { get; set; }

        [Range(0, 2000)]
        public int ShotsOfTarget { get; set; }

        [Range(0, 2000)]
        public int Corners { get; set; }

        [Range(0, 2000)]
        public int BallPossessions { get; set; }

        [Range(0, 2000)]
        public int TrollIns { get; set; }

        [Range(0, 2000)]
        public int Falls { get; set; }

        [Range(0, 2000)]
        public int OffSites { get; set; }

        public ICollection<TeamKeyValue> Teams { get; set; } = new HashSet<TeamKeyValue>();
    }
}
