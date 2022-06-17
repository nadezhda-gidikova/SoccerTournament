namespace SoccerTournament.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoccerTournament.Models.Competition;
    using SoccerTournament.Models.Game;
    using SoccerTournament.Services;

    public class CompetitionsController:Controller
    {
        private readonly ICompetitionService competittionService;
        private readonly IGameService gameService;

        public CompetitionsController(ICompetitionService competittionService,IGameService gameService)
        {
            this.competittionService = competittionService;
            this.gameService = gameService;
        }

        public async Task<IActionResult> Create()
        {

            var model = new CompetitionFormModel
            {
                Games = await this.gameService.GetAllByIdInListAsync<GameViewModel>(),
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompetitionFormModel model)
        {


           

            if (!ModelState.IsValid)
            {
                model.Games = await this.gameService.GetAllByIdInListAsync<GameViewModel>();
                return View(model);
            }
            var newGame = await this.competittionService.(model);
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
