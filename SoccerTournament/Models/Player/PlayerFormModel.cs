namespace SoccerTournament.Models.Player
{
    using SoccerTournament.Data.Models;
    using SoccerTournament.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class PlayerFormModel :IMapTo<Player>,IMapFrom<Player>
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]    
        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PictureUrl { get; set; }

        public string Position { get; set; }

        [Range(0, 2000)]
        public int Number { get; set; }

        public int? TeamId { get; set; }

        [Range(0, 2000)]
        public int Goals { get; set; }

        [Range(0, 2000)]
        public int Assistances { get; set; }

        [Range(0, 2000)]
        public double AverageRating { get; set; }

        [Range(0, 2000)]
        public int YellowCards { get; set; }

        [Range(0, 2000)]
        public int RedCards { get; set; }

        [Range(0, 2000)]
        public int Takle { get; set; }

      
    }
}
