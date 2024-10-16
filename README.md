# Pasos

Descargar Microsoft.EntityFrameworkCore.InMemory en NuGet (Si no usamos base de datos)

o

Descargar Microsoft.EntityFrameworkCore.Sqlite en NuGet (Para una persistencia de datos y rapidez)

Si usamos SQLite debemos agregar el "DefaultConnection" en nuestro appsettings.json:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  // Aqui se agrega la cadena de conexion
  "ConnectionStrings": {
    // Cadena de conexion por defecto
    "DefaultConnection": "Data Source=Application.db;"
  },
  "AllowedHosts": "*"
}
```

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
        // Aqui mismo se agregaran las siguientes relaciones
    }
```

Registramos los servicios de base de datos en Program.cs
```
// UseInMemoryDatabase
// builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
// o
// Sqlite
// builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

Generamos los controladores con scafolding usando visual studio (ChefsController y RecipeController)
