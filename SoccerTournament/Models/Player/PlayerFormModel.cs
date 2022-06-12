namespace SoccerTournament.Models.Player
{
    using SoccerTournament.Data.Models;
    using SoccerTournament.Mapping;

    public class PlayerFormModel :IMapTo<Player>,IMapFrom<Player>
    {
        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Position { get; set; }

        public int Number { get; set; }

        public int TeamId { get; set; }

        public int Goals { get; set; }

        public int Assistances { get; set; }

        public double AverageRating { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int Takle { get; set; }
    }
}
