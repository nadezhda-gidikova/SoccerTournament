namespace SoccerTournament.Models.Game
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;

    public class GameViewModel:IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public int WinnnerTeamName { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public int Goals { get; set; }

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
    }
}
