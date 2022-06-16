namespace SoccerTournament.Models.Coach
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;

    public class CoachViewModel:IMapFrom<Coach>,IMapTo<Coach>
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
