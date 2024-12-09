namespace GameZone.ViewModel
{
    public class GameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int categoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Select Devices")]
        public List<int> SelectDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Description")]
        [MaxLength(10000)]
        public string Description { get; set; } = string.Empty;
    }
}
