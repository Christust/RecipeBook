using System.Text.Json.Serialization;

namespace RecipeBook.Models
{
    public class Chef
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        [JsonIgnore]
        public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
    }
}
