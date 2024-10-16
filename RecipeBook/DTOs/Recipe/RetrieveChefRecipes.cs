namespace RecipeBook.DTOs.Recipe
{
    public class RetrieveChefRecipes
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
