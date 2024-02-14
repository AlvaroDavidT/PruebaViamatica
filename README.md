compilar la solucion:

   dotnet build;   

Crear las migraciones :

dotnet ef migrations add InitialMigration10 -p src/Infrastructure -s src/Web.API -o Persistence/Migrations/; 

Actualizar la base de datos:

dotnet ef database update -p src/Infrastructure -s src/Web.API;      
