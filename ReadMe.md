1. 
dotnet add src/EducationCenter.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/EducationCenter.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef
2. dotnet ef migrations add InitialCreate
