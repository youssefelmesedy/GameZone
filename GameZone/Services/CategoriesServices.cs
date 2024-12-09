
namespace GameZone.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ApplicationDbContext _context;

        public CategoriesServices(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<SelectListItem> GetSlecteListCategories()
        {
                return _context.categories.Select(c =>
                new SelectListItem
                { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
