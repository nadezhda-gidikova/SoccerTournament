namespace SoccerTournament.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoccerTournament.Models.Game;
    using SoccerTournament.Models.Team;
    using SoccerTournament.Services;

    public class GamesController:Controller
    {
        private readonly IGameService gameService;
        private readonly ITeamService teamService;

        public GamesController(IGameService gameService,ITeamService teamService)
        {
            this.gameService = gameService;
            this.teamService = teamService;
        }
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> Create()
        {
            
            var model = new GameFormModel
            {
                Teams = await this.teamService.GetAllInList<TeamKeyValue>(),
            };
            return this.View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(GameFormModel model)
        {

            
            var homeTeamId = await this.teamService.GetByIdAsync<TeamKeyValue>(model.HomeTeamId);
            if (homeTeamId == null)
            {
                this.ModelState.AddModelError(nameof(model.HomeTeamId), $"Team with Id:{model.HomeTeamId} does not exist.");
            }
            var awayTeamId = await this.teamService.GetByIdAsync<TeamKeyValue>(model.AwayTeamId);
            if (awayTeamId == null)
            {
                this.ModelState.AddModelError(nameof(model.AwayTeamId), $"Team with Id:{model.AwayTeamId} does not exist.");
            }
            var winTeamId = await this.teamService.GetByIdAsync<TeamKeyValue>(model.WinnnerTeamId);
            if (winTeamId == null)
            {
                this.ModelState.AddModelError(nameof(model.WinnnerTeamId), $"Team with Id:{model.WinnnerTeamId} does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Teams = await this.teamService.GetAllInList<TeamKeyValue>();
                return View(model);
            }
            var newGame = await this.gameService.CreateTeamAsync(model);
            return RedirectToAction(nameof(GetAllById));
        }

        public async Task<IActionResult> GetAllById(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new GameListViewModel
            {
                Games = await this.gameService.GetAllByIdAsync<GameInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);

        }
        public async Task<IActionResult> GetById(int id)
        {
            var playerNew = await this.gameService.GetByIdAsync<GameViewModel>(id);
            if (playerNew == null)
            {
                return this.NotFound();
            }

            return this.View(playerNew);
        }
    }
}
