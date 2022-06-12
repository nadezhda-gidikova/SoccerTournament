namespace SoccerTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("Coach")]
        [Required]
        public int CoachId { get; set; }

        public virtual Coach Coach { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public virtual ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();

        public virtual ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();

        public virtual ICollection<Game> GamesWin { get; set; } = new HashSet<Game>();


    }
}