namespace SoccerTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Competition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }=new HashSet<Team>();

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();

        [ForeignKey("Winner")]
        public int WinnerId { get; set; }

        public virtual Team Winner { get; set; }
    }
}
