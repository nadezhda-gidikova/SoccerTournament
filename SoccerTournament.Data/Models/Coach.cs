namespace SoccerTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Coach
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        [Required]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}