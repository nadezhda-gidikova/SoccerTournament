namespace SoccerTournament.Models.Game
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Team;

    public class GameFormModel:IMapFrom<Game>
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public string Referee { get; set; }

        public int WinnnerTeamId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public string Stage { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int ShotsOnTarget { get; set; }

        public int ShotsOfTarget { get; set; }

        public int Corners { get; set; }

        public int BallPossessions { get; set; }

        public int TrollIns { get; set; }

        public int Falls { get; set; }

        public int OffSites { get; set; }

        public ICollection<TeamKeyValue> Teams { get; set; } = new HashSet<TeamKeyValue>();
    }
}
