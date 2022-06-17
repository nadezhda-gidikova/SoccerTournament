namespace SoccerTournament.Models.Game
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;

    public class GameInListViewModel:IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
