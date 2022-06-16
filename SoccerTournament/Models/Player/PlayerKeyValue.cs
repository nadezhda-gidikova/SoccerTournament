namespace SoccerTournament.Models.Player
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;

    public class PlayerKeyValue:IMapFrom<Player>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }
    }
}
