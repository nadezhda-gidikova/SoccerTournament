namespace SoccerTournament.Models.Team
{
    using SoccerTournament.Mapping;
    using SoccerTournament.Data.Models;
    using SoccerTournament.Models.Player;
    using AutoMapper;

    public class TeamViewModel:IMapFrom<Team>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Emblem { get; set; }

        public string CoachFullName { get; set; }

        public string CountryName { get; set; }

        public IEnumerable<PlayerInListViewModel> TeamPlayers { get; set; } = new List<PlayerInListViewModel>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(x => x.TeamPlayers, opt =>
                    opt.MapFrom(x =>
                       x.Players));
        }
    }
}
