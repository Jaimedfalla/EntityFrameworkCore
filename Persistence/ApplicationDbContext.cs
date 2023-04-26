using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.interceptors;

namespace Persistence.Database;

public class ApplicationDbContext:DbContext
{
    public readonly AuditableInterceptor _interceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableInterceptor interceptor):base(options)
    {
        _interceptor =  interceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Domain.Configurations.ActorConfiguration)));
        InitialSeeding.Seed(modelBuilder);

        //El siguiente es código ayuda a automatizar las configuraciones
        foreach(var entidad in modelBuilder.Model.GetEntityTypes())
        {
            foreach(var property in entidad.GetProperties())
            {
                if(property.ClrType == typeof(string) && property.Name.Contains("URL",StringComparison.CurrentCultureIgnoreCase))
                {
                    property.SetIsUnicode(false);
                    property.SetMaxLength(500);
                }
            }
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //Configura por defecto los campos de tipo string a una longitud de NVARCHAR(150)
        configurationBuilder.Properties<string>().HaveMaxLength(150);
        configurationBuilder.Properties<DateTime>().HaveColumnType("date");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
    }

    public DbSet<Gender> Genders => Set<Gender>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<MovieActor> MoviesActors => Set<MovieActor>();
    public DbSet<Cinema> Cinemas => Set<Cinema>();
    public DbSet<CinemaOffer> Offers => Set<CinemaOffer>();
    public DbSet<MovieTheater> MovieTheaters => Set<MovieTheater>();
    public DbSet<Log> Logs => Set<Log>();
}