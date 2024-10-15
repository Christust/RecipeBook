# Pasos

Descargar Microsoft.EntityFrameworkCore.InMemory en NuGet

Crear la carpeta Models

Creamos los modelos Chef y Recipe. (One to Many)
	- Un chef puede tener N recetas
	- Una receta solo puede pertenecer a un chef

Crear la carpeta Data

Creamos la clase DataContext
	- Registramos el dbset Chefs
	- Registramos el dbset Recipes
	- Registramos la relacion uno a muchos de Chefs y Recipes:
	```
	protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chef>()
                .HasMany(e => e.Recipes)
                .WithOne(e => e.Chef)
                .HasForeignKey(e => e.ChefId)
                .IsRequired();
        }
	```
Registramos los servicios de base de datos en Program.cs
```
// De momento usamos UseInMemoryDatabase para pruebas
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
```

Generamos los controladores con scafolding usando visual studio (ChefsController y RecipeController)


