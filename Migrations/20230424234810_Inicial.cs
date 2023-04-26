using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Fortune = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsPlaying = table.Column<bool>(type: "bit", nullable: false),
                    Premiere = table.Column<DateTime>(type: "date", nullable: false),
                    PosterUrl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaOffer_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTheaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "ThreeD"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheaters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTheaters_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenderMovie",
                columns: table => new
                {
                    GendersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderMovie", x => new { x.GendersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenderMovie_Gender_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenderMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesActors", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MoviesActors_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesActors_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieMovieTheater",
                columns: table => new
                {
                    MovieTheatersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieTheater", x => new { x.MovieTheatersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieMovieTheater_MovieTheaters_MovieTheatersId",
                        column: x => x.MovieTheatersId,
                        principalTable: "MovieTheaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMovieTheater_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Biography", "BirthDate", "Fortune", "Name" },
                values: new object[,]
                {
                    { 1, "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico.", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000000m, "Tom Holland" },
                    { 2, "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto.", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000000m, "Samuel L. Jackson" },
                    { 3, "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 420000000m, "Robert Downey Jr." },
                    { 4, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 39000000m, "Chris Evans" },
                    { 5, null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49000000m, "Dwayne Johnson" },
                    { 6, null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Auli'i Cravalho" },
                    { 7, null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Scarlett Johansson" },
                    { 8, null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Keanu Reeves" }
                });

            migrationBuilder.InsertData(
                table: "Cinema",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)"), "Agora Mall" },
                    { 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)"), "Sambil" },
                    { 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)"), "Megacentro" },
                    { 4, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)"), "Acropolis" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Acción" },
                    { 2, false, "Animación" },
                    { 3, false, "Comedy" },
                    { 4, false, "Ciencia ficción" },
                    { 5, false, "Dramma" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "IsPlaying", "PosterUrl", "Premiere", "Title" },
                values: new object[,]
                {
                    { 1, false, "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers" },
                    { 2, false, "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg", new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco" },
                    { 3, false, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No way home" },
                    { 4, false, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: Far From Home" },
                    { 5, true, "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg", new DateTime(2100, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Resurrections" }
                });

            migrationBuilder.InsertData(
                table: "CinemaOffer",
                columns: new[] { "Id", "CinemaId", "Discount", "EndDate", "InitialDate" },
                values: new object[,]
                {
                    { 1, 1, 10m, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 4, 15m, new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "GenderMovie",
                columns: new[] { "GendersId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "MovieTheaters",
                columns: new[] { "Id", "CinemaId", "Currency", "Price", "Type" },
                values: new object[,]
                {
                    { 1, 1, "", 220m, "TwoD" },
                    { 2, 1, "", 320m, "ThreeD" },
                    { 3, 2, "", 200m, "TwoD" },
                    { 4, 2, "", 290m, "ThreeD" },
                    { 5, 3, "", 250m, "TwoD" },
                    { 6, 3, "", 330m, "ThreeD" },
                    { 7, 3, "", 450m, "FourD" },
                    { 8, 4, "", 250m, "TwoD" }
                });

            migrationBuilder.InsertData(
                table: "MoviesActors",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { 1, 3, "Peter Parker", 1 },
                    { 1, 4, "Peter Parker", 1 },
                    { 2, 4, "Samuel L. Jackson", 2 },
                    { 3, 1, "Iron Man", 2 },
                    { 4, 1, "Capitán América", 1 },
                    { 7, 1, "Black Widow", 3 },
                    { 8, 5, "Neo", 1 }
                });

            migrationBuilder.InsertData(
                table: "MovieMovieTheater",
                columns: new[] { "MovieTheatersId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 6, 5 },
                    { 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaOffer_CinemaId",
                table: "CinemaOffer",
                column: "CinemaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Name",
                table: "Gender",
                column: "Name",
                unique: true,
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_GenderMovie_MoviesId",
                table: "GenderMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieTheater_MoviesId",
                table: "MovieMovieTheater",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_MovieId",
                table: "MoviesActors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaters_CinemaId",
                table: "MovieTheaters",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaOffer");

            migrationBuilder.DropTable(
                name: "GenderMovie");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "MovieMovieTheater");

            migrationBuilder.DropTable(
                name: "MoviesActors");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "MovieTheaters");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}
