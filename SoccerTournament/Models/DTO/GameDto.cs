namespace SoccerTournament.Models.DTO
{
    using SoccerTournament.Models.Game;
    using SoccerTournament.Models.Player;

    public class GameDto
    {
        public GameViewModel Goals { get; set; }

        public GameViewModel RedCarts { get; set; }

        public GameViewModel OffSites { get; set; }

        public GameViewModel Corners { get; set; }

        public PlayerViewModel PlayerGoals { get; set; }

        public PlayerViewModel PlayerRedCard { get; set; }

        public PlayerViewModel PlayerYellowCard { get; set; }

        public PlayerViewModel PlayerAssisstances { get; set; }

        public PlayerViewModel PlayerRating { get; set; }


    }
}
