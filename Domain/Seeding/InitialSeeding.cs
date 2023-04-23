using ef7_example.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace ef7_example.Domain.Entities;

public class InitialSeeding
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var action = new Gender { Id = 1, Name = "Acción" };
        var animation = new Gender { Id = 2, Name = "Animación" };
        var comedy = new Gender { Id = 3, Name = "Comedy" };
        var scienceFiction = new Gender { Id = 4, Name = "Ciencia ficción" };
        var dramma = new Gender { Id = 5, Name = "Dramma" };

        modelBuilder.Entity<Gender>().HasData(action, animation, comedy, scienceFiction, dramma);

        var tomHolland = new Actor() { 
            Id = 1, Name = "Tom Holland",
            BirthDate = new DateTime(1996, 6, 1),
            Fortune = 1000000,
            Biography = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
        
        var samuelJackson = new Actor() {
            Id = 2,
            Name = "Samuel L. Jackson",
            BirthDate = new DateTime(1948, 12, 21),
            Fortune = 2000000,
            Biography = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
        
        var robertDowney = new Actor() {
            Id = 3,
            Name = "Robert Downey Jr.",
            BirthDate = new DateTime(1965, 4, 4),
            Fortune = 420000000,
            Biography = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
        
        var chrisEvans = new Actor() {
            Id = 4,
            Name = "Chris Evans",
            BirthDate = new DateTime(1981, 06, 13),
            Fortune = 39000000
        };

        var laRoca = new Actor() {
            Id = 5,
            Name = "Dwayne Johnson",
            BirthDate = new DateTime(1972, 5, 2),
            Fortune = 49000000
        };

        var auliCravalho = new Actor() {
            Id = 6,
            Name = "Auli'i Cravalho",
            BirthDate = new DateTime(2000, 11, 22)
        };

        var scarlettJohansson = new Actor() { Id = 7, Name = "Scarlett Johansson", BirthDate = new DateTime(1984, 11, 22) };
        var keanuReeves = new Actor() { Id = 8, Name = "Keanu Reeves", BirthDate = new DateTime(1964, 9, 2) };

        modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                        robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        var agora = new Cinema() { Id = 1, Name = "Agora Mall", Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
        var sambil = new Cinema() { Id = 2, Name = "Sambil", Location = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
        var megacentro = new Cinema() { Id = 3, Name = "Megacentro", Location = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
        var acropolis = new Cinema() { Id = 4, Name = "Acropolis", Location = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

        var agoraCineOferta = new CinemaOffer { Id = 1, CinemaId = agora.Id, InitialDate = DateTime.Today, EndDate = DateTime.Today.AddDays(7), Discount = 10 };

        var movieTheater2DAgora = new MovieTheater()
        {
            Id = 1,
            CinemaId = agora.Id,
            Price = 220,
            Type = MovieTheaterType.TwoD
        };
        
        var movieTheater3DAgora = new MovieTheater()
        {
            Id = 2,
            CinemaId = agora.Id,
            Price = 320,
            Type = MovieTheaterType.ThreeD
        };

        var movieTheater2DSambil = new MovieTheater()
        {
            Id = 3,
            CinemaId = sambil.Id,
            Price = 200,
            Type = MovieTheaterType.TwoD
        };

        var movieTheater3DSambil = new MovieTheater()
        {
            Id = 4,
            CinemaId = sambil.Id,
            Price = 290,
            Type = MovieTheaterType.ThreeD
        };

        var movieTheater2DMegacentro = new MovieTheater()
        {
            Id = 5,
            CinemaId = megacentro.Id,
            Price = 250,
            Type = MovieTheaterType.TwoD
        };
        var movieTheater3DMegacentro = new MovieTheater()
        {
            Id = 6,
            CinemaId = megacentro.Id,
            Price = 330,
            Type = MovieTheaterType.ThreeD
        };
        var movieTheaterCXCMegacentro = new MovieTheater()
        {
            Id = 7,
            CinemaId = megacentro.Id,
            Price = 450,
            Type = MovieTheaterType.FourD
        };

        var movieTheater2DAcropolis = new MovieTheater()
        {
            Id = 8,
            CinemaId = acropolis.Id,
            Price = 250,
            Type = MovieTheaterType.TwoD
        };

        var acropolisCineOferta = new CinemaOffer { Id = 2, CinemaId = acropolis.Id, InitialDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5), Discount = 15 };
        modelBuilder.Entity<Cinema>().HasData(acropolis, sambil, megacentro, agora);
        modelBuilder.Entity<CinemaOffer>().HasData(acropolisCineOferta, agoraCineOferta);
        modelBuilder.Entity<MovieTheater>().HasData(movieTheater2DMegacentro, movieTheater3DMegacentro, movieTheaterCXCMegacentro, movieTheater2DAcropolis, movieTheater2DAgora, movieTheater3DAgora, movieTheater2DSambil, movieTheater3DSambil);

        var avengers = new Movie()
        {
            Id = 1,
            Title = "Avengers",
            IsPlaying = false,
            Premiere = new DateTime(2012, 4, 11),
            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
        };

        var coco = new Movie()
        {
            Id = 2,
            Title = "Coco",
            IsPlaying = false,
            Premiere = new DateTime(2017, 11, 22),
            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
        };

        var noWayHome = new Movie()
        {
            Id = 3,
            Title = "Spider-Man: No way home",
            IsPlaying = false,
            Premiere = new DateTime(2021, 12, 17),
            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
        };

        var farFromHome = new Movie()
        {
            Id = 4,
            Title = "Spider-Man: Far From Home",
            IsPlaying = false,
            Premiere = new DateTime(2019, 7, 2),
            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
        };

        var theMatrixResurrections = new Movie()
        {
            Id = 5,
            Title = "The Matrix Resurrections",
            IsPlaying = true,
            Premiere = new DateTime(2100, 1, 1),
            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
        };

        //Forma de crear el seeding para una relación muchos a muchos con salto
        var genderMovieEntity = "GenderMovie";
        var genderIdProperty = "GendersId";
        var movieIdProperty = "MoviesId";

        var movieTheaterEntity = "MovieMovieTheater";
        var movieTheaterProperty = "MovieTheatersId";

        modelBuilder.Entity(genderMovieEntity).HasData(
            new Dictionary<string, object> { [genderIdProperty] = action.Id, [movieIdProperty] = avengers.Id },
            new Dictionary<string, object> { [genderIdProperty] = scienceFiction.Id, [movieIdProperty] = avengers.Id }
        );

        modelBuilder.Entity(genderMovieEntity).HasData(
            new Dictionary<string, object> { [genderIdProperty] = animation.Id, [movieIdProperty] = coco.Id }
        ); 

        modelBuilder.Entity(genderMovieEntity).HasData(
            new Dictionary<string, object> { [genderIdProperty] = scienceFiction.Id, [movieIdProperty] = noWayHome.Id },
            new Dictionary<string, object> { [genderIdProperty] = action.Id, [movieIdProperty] = noWayHome.Id },
            new Dictionary<string, object> { [genderIdProperty] = comedy.Id, [movieIdProperty] = noWayHome.Id }
        );

        modelBuilder.Entity(genderMovieEntity).HasData(
            new Dictionary<string, object> { [genderIdProperty] = scienceFiction.Id, [movieIdProperty] = farFromHome.Id },
            new Dictionary<string, object> { [genderIdProperty] = action.Id, [movieIdProperty] = farFromHome.Id },
            new Dictionary<string, object> { [genderIdProperty] = comedy.Id, [movieIdProperty] = farFromHome.Id }
        );

        modelBuilder.Entity(genderMovieEntity).HasData(
            new Dictionary<string, object> { [genderIdProperty] = scienceFiction.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [genderIdProperty] = action.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [genderIdProperty] = dramma.Id, [movieIdProperty] = theMatrixResurrections.Id }
        );

        modelBuilder.Entity(movieTheaterEntity).HasData(
            new Dictionary<string, object> { [movieTheaterProperty] = movieTheater2DSambil.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [movieTheaterProperty] = movieTheater3DSambil.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [movieTheaterProperty] = movieTheater2DAgora.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [movieTheaterProperty] = movieTheater3DAgora.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [movieTheaterProperty] = movieTheater2DMegacentro.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [movieTheaterProperty] = movieTheater3DMegacentro.Id, [movieIdProperty] = theMatrixResurrections.Id },
            new Dictionary<string, object> { [movieTheaterProperty] = movieTheaterCXCMegacentro.Id, [movieIdProperty] = theMatrixResurrections.Id }
         );

        //Seeding para una relación muchos a muchos sin salto
            var keanuReevesMatrix = new MovieActor
            {
                ActorId = keanuReeves.Id,
                MovieId = theMatrixResurrections.Id,
                Order = 1,
                Character = "Neo"
            };

            var avengersChrisEvans = new MovieActor
            {
                ActorId = chrisEvans.Id,
                MovieId = avengers.Id,
                Order = 1,
                Character = "Capitán América"
            };

            var avengersRobertDowney = new MovieActor
            {
                ActorId = robertDowney.Id,
                MovieId = avengers.Id,
                Order = 2,
                Character = "Iron Man"
            };

            var avengersScarlettJohansson = new MovieActor
            {
                ActorId = scarlettJohansson.Id,
                MovieId = avengers.Id,
                Order = 3,
                Character = "Black Widow"
            };

            var tomHollandFFH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = farFromHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var tomHollandNWH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = noWayHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var samuelJacksonFFH = new MovieActor
            {
                ActorId = samuelJackson.Id,
                MovieId = farFromHome.Id,
                Order = 2,
                Character = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Movie>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            modelBuilder.Entity<MovieActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);
    }
}