namespace SoccerTournament.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SoccerTournament.Data;
    using SoccerTournament.Models.Competition;
    using SoccerTournament.Models.Game;
    using SoccerTournament.Services;

    public class CompetitionsController:Controller
    {
        private readonly ICompetitionService competittionService;
        private readonly IGameService gameService;
        private readonly ApplicationDbContext db;

        public CompetitionsController(ICompetitionService competittionService,IGameService gameService,ApplicationDbContext db)
        {
            this.competittionService = competittionService;
            this.gameService = gameService;
            this.db = db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.games = this.db.Games.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name }).ToList();
           
            return this.View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CompetitionFormModel model)
        {
            foreach (var game in model.GamesSelectList)
            {
                var gameselected = await this.gameService.GetByIdAsync<GameKeyValue>(game);
                if (gameselected == null)
                {
                    this.ModelState.AddModelError(nameof(model.Games), $"Game with Id:{game} does not exist.");
                }
            }
            if (!ModelState.IsValid)
            {     
                return View(model);
            }
            var newCompetition = await this.competittionService.CreateCompetitionAsync(model);
            foreach (var game in model.GamesSelectList)
            {
                await this.competittionService.AddGamesToCompetitions(game, newCompetition.Id);
            }
            return RedirectToAction(nameof(GetAllById));
        }

        public async Task<IActionResult> GetAllById(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new CompetitionListViewModel
            {
                Competitions = await this.competittionService.GetAllByIdAsync<CompetitionInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);

        }
        public async Task<IActionResult> GetById(int id)
        {
            var playerNew = await this.competittionService.GetByIdAsync<CompetitionViewModel>(id);
            if (playerNew == null)
            {
                return this.NotFound();
            }

            return this.View(playerNew);
        }
    }
}
