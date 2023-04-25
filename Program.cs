using Microsoft.EntityFrameworkCore;
using ef7_example.Infraestructure.Database;
using System.Reflection;
using ef7_example.Domain.interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    //La siguiente línea es muy importante para que no error en la serialización de los objetos con referencia circular
    options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    {
        options.UseSqlServer(connection,
            //NetTopologySuite es una librería para guardar coordenadas de una ubicación usando EFCore
            sqlServer => sqlServer.UseNetTopologySuite()
        );

        //Hace que todas las consultas por defecto no tengan Tracking o seguimiento, lo que las hace más eficientes
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<AuditableInterceptor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
