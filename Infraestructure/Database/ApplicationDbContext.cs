using System.Reflection;
using ef7_example.Domain.Configurations;
using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ef7_example.Infraestructure.Database;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
     
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        InitialSeeding.Seed(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //Configura por defecto los campos de tipo string a una longitud de NVARCHAR(150)
        configurationBuilder.Properties<string>().HaveMaxLength(150);
        configurationBuilder.Properties<DateTime>().HaveColumnType("date");
    }

    public DbSet<Gender> Genders => Set<Gender>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Comment> Comentarios => Set<Comment>();
    public DbSet<MovieActor> MoviesActors => Set<MovieActor>();
    public DbSet<Cinema> Cinemas => Set<Cinema>();
    public DbSet<CinemaOffer> Offers => Set<CinemaOffer>();
    public DbSet<MovieTheater> MovieTheaters => Set<MovieTheater>();
}