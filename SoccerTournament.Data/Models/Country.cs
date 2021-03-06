namespace SoccerTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}