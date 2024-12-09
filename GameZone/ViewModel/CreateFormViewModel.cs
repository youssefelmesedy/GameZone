namespace GameZone.ViewModel
{
    public class CreateFormViewModel : GameFormViewModel
    {
        // Validate Extension And Size
        [AllowedExtenions(FileStettings.AllowedExtensions), MaxFileSize(FileStettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
