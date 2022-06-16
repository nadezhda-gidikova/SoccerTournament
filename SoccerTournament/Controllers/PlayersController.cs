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
            if (!ModelState.IsValid)
            {
                return View();
            }
            var playerNew= await player.CreatePlayerAsync(input);
            return RedirectToAction(nameof(GetAllByName));
        }

        public async Task<IActionResult> GetById(int id)
        {
            var playerNew=await this.player.GetByIdAsync<PlayerViewModel>(id);

            return this.View(playerNew);
        }

        public async Task<IActionResult> GetAllByName(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new PlayerListViewModel
            {
                Players = await this.player.GetAllPlayersBYFirstNameAsync<PlayerInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
           
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await player.DeletePlayerByIdAsync(Id);
            return RedirectToAction(nameof(GetAllByName));
        }

    }
}
