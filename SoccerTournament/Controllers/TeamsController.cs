namespace SoccerTournament.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SoccerTournament.Data;
    using SoccerTournament.Models.Coach;
    using SoccerTournament.Models.Player;
    using SoccerTournament.Models.Team;
    using SoccerTournament.Services;

    public class TeamsController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IPlayerService playerService;
        private readonly ICoachService coachService;
        private readonly ApplicationDbContext db;

        public TeamsController(ITeamService teamService, IPlayerService playerService, ICoachService coachService,ApplicationDbContext db)
        {
            this.teamService = teamService;
            this.playerService = playerService;
            this.coachService = coachService;
            this.db = db;
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.players = this.db.Players.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.FirstName+" "+r.FamilyName }).ToList();
            var model = new TeamFormModel
            {
                
                Coaches = await this.coachService.GetCoachesKeyValueAsync<CoachViewModel>(),
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamFormModel model)
        {

            foreach (var player in model.PlayersSelectList)
            {
                var playersSelcted = await this.playerService.GetByIdAsync<PlayerViewModel>(player);
                if (playersSelcted == null)
                {
                    this.ModelState.AddModelError(nameof(model.Players), $"Player with Id:{player} does not exist.");
                }
            }
            var coachId = await this.coachService.GetByIdAsync<CoachViewModel>(model.CoachId);
            if (coachId == null)
            {
                this.ModelState.AddModelError(nameof(model.CoachId), $"Coach with Id:{model.CoachId} does not exist.");
            }

            if (!ModelState.IsValid)
            {
               
                model.Coaches = await this.coachService.GetCoachesKeyValueAsync<CoachViewModel>();
                return View(model);
            }
            var newTeam = await this.teamService.CreateTeamAsync(model);
            return RedirectToAction(nameof(GetAllById));
        }


        public async Task<IActionResult> GetAllById(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new TeamListViewModel
            {
                Teams = await this.teamService.GetAllTeamsByIdAsync<TeamInLIstViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);

        }
    }


}
