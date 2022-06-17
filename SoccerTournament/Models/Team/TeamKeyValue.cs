namespace SoccerTournament.Models.Team
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;

    public class TeamKeyValue:IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
