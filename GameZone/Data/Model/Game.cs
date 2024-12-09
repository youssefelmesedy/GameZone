namespace GameZone.Data.Model
{
    public class Game : BaseEntity
    {
        [MaxLength(10000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;

        public int categoryId { get; set; }
        public Category category { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
    }
}
