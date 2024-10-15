namespace RecipeBook.DTOs.Recipe
{
    public class ChefRecipes
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
