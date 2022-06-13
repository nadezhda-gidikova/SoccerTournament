namespace SoccerTournament.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoccerTournament.Models.Player;
    using SoccerTournament.Services;

    public class PlayersController:Controller
    {
        private readonly IPlayerService player;

        public PlayersController(IPlayerService player)
        {
            this.player = player;
        }

        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PlayerFormModel input)
        {
            var playerNew= await player.CreatePlayerAsync(input);
            return RedirectToAction($"GetById/{playerNew.Id }");
        }

        public async Task<IActionResult> GetById(int id)
        {
            var playerNew=await this.player.GetByIdAsync<PlayerViewModel>(id);

            return this.View(playerNew);
        }
    }
}
