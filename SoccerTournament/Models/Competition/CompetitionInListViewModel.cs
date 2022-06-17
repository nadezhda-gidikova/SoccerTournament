namespace SoccerTournament.Models.Competition
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;

    public class CompetitionInListViewModel:IMapFrom<Competition>
    {
        public int Id { get; set; }

        public string Name { get; set; }


    }
}
