using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;
using System.Reflection.Metadata;

namespace RecipeBook.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chef>()
                .HasMany(e => e.Recipes)
                .WithOne(e => e.Chef)
                .HasForeignKey(e => e.ChefId)
                .IsRequired();
        }

    }
}
