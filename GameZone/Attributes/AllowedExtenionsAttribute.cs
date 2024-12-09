namespace GameZone.Attributes
{
    public class AllowedExtenionsAttribute : ValidationAttribute
    {
         private readonly string _allowedExtensions;
        public AllowedExtenionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtensions} are Allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
