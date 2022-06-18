namespace SoccerTournament.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoccerTournament.Models;
    using SoccerTournament.Models.DTO;
    using SoccerTournament.Models.Game;
    using SoccerTournament.Models.Player;
    using SoccerTournament.Services;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameStatistics gameStatistics;

        public HomeController(ILogger<HomeController> logger, IGameStatistics gameStatistics)
        {
            _logger = logger;
            this.gameStatistics = gameStatistics;
        }

        public async Task<IActionResult> Index()
        {


            var model = new GameDto
            {
                Goals = await this.gameStatistics.GameWithMostGoals<GameViewModel>(),
                Corners = await this.gameStatistics.GameWithMostCorners<GameViewModel>(),
                OffSites = await this.gameStatistics.GameWithMostOffSites<GameViewModel>(),
                RedCarts = await this.gameStatistics.GameWithMostRedCards<GameViewModel>(),
                PlayerGoals = await this.gameStatistics.PlayersWithMostRedCards<PlayerViewModel>(),
                PlayerRating = await this.gameStatistics.PlayersWithBiggestRating<PlayerViewModel>(),
                PlayerRedCard = await this.gameStatistics.PlayersWithMostRedCards<PlayerViewModel>(),
                PlayerYellowCard = await this.gameStatistics.PlayersWithMostYellowCards<PlayerViewModel>(),
                PlayerAssisstances = await this.gameStatistics.PlayersWithMostAssistances<PlayerViewModel>(),
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}