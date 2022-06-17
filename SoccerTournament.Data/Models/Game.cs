namespace SoccerTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public int Id { get; set; }

      
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        [Required]
        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        [ForeignKey("Referee")]
        public int RefereeId { get; set; }
            
        public Referee Referee { get; set; }

        [Required]
        [ForeignKey("WinnnerTeam")]
        public int WinnnerTeamId { get; set; }

     
        public Team WinnerTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        [Required]
        public Stage Stage { get; set; }

        public int Goals { get; set; }

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
