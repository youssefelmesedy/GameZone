namespace GameZone.ViewModel
{
    public class EditGameViewModelForm : GameFormViewModel
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }

        // Validate Extension And Size
        [AllowedExtenions(FileStettings.AllowedExtensions), MaxFileSize(FileStettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
