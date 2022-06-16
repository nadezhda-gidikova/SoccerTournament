namespace SoccerTournament.Models.Team
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;

    public class TeamInLIstViewModel:IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Emblem { get; set; }

        public string Country { get; set; }

  
        
    }
}
