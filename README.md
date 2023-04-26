# EntityFrameworkCore
A single project to improve ef knowledge

## Installing EF globally

```
dotnet tool install --global dotnet-ef
```

## For add migration

```
dotnet ef migrations add <name> --project .\Migrations\Migrations.csproj --startup-project .\webapi\webapi.csproj --context ApplicationDbContext
```

## For update database

```
dotnet ef database update --startup-project ..\webapi\webapi.csproj --context ApplicationDbContext
```
