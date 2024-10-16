namespace RecipeBook.DTOs.Chef
{
    public class RetrieveChef
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public ICollection<Recipe.RetrieveChefRecipes> Recipes { get; set; } = new List<Recipe.RetrieveChefRecipes>();
    }
}
