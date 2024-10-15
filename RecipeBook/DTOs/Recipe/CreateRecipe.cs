namespace RecipeBook.DTOs.Recipe
{
    public class CreateRecipe
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int ChefId { get; set; }
    }
}
