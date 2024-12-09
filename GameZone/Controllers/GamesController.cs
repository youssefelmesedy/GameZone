namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGameService _gameServices;
        public GamesController(ICategoriesServices categoriesServices, IDevicesServices devicesServices, IGameService gameServices)
        {
            _categoriesServices = categoriesServices;
            _devicesServices = devicesServices;
            _gameServices = gameServices;
        }
        public IActionResult Index()
        {
            var games = _gameServices.GetAll();
            return View(games);
        }
        public IActionResult Details(int id)
        {
            var game = _gameServices.GetById(id);
            if (game is null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateFormViewModel viewModel = new()
            {
                Categories = _categoriesServices.GetSlecteListCategories(),
                Devices = _devicesServices.GetSelectListDevices(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSlecteListCategories();
                model.Devices = _devicesServices.GetSelectListDevices();
                return View(model);
            }
            // Save Game 
            // Save Cover to Server
            await _gameServices.Create(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gameServices.GetById(id);
            if (game is null)
                return NotFound();

            EditGameViewModelForm viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                categoryId = game.categoryId,
                SelectDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _categoriesServices.GetSlecteListCategories(),
                Devices = _devicesServices.GetSelectListDevices(),
                CurrentCover = game.Cover,
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameViewModelForm model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSlecteListCategories();
                model.Devices = _devicesServices.GetSelectListDevices();
                return View(model);
            }

            var game = await _gameServices.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gameServices.Delete(id);

            return isDeleted? Ok() : BadRequest();
        }
    }
}
