namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameServices;

        public HomeController(IGameService gameServices)
        {
            _gameServices = gameServices;
        }
        public IActionResult Index()
        {
            var games = _gameServices.GetAll();
            return View(games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
