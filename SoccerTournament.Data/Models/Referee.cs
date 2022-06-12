namespace SoccerTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Referee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}