using Newtonsoft.Json;

namespace RecipeBook.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int ChefId { get; set; }
        [JsonIgnore]
        public Chef Chef { get; set; } = null!;

    }
}
