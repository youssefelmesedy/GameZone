
namespace GameZone.Services
{
    public class DevicesServices : IDevicesServices
    {
        private readonly ApplicationDbContext _context;

        public DevicesServices(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<SelectListItem> GetSelectListDevices()
        {
            return _context.devices.Select(c =>
                new SelectListItem
                { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
