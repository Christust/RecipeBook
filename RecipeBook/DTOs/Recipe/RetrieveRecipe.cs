using RecipeBook.Models;

namespace RecipeBook.DTOs.Recipe
{
    public class RetrieveRecipe
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int ChefId { get; set; }
        public RecipeBook.Models.Chef Chef { get; set; } = null!;
    }
}
