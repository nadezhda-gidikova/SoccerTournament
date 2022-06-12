namespace SoccerTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PictureUrl { get; set; }

        public Position Position { get; set; }

        public int Number { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public int Goals { get; set; }

        public int Assistances { get; set; }

        public double AverageRating { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int Takle { get; set; }

        

    }
}