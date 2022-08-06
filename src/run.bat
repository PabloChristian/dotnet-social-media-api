dotnet clean

dotnet restore

dotnet build

dotnet tool install --global dotnet-ef

dotnet ef database update --startup-project .\Posterr.Api

start dotnet watch run --project .\Posterr.Api

echo "Chrome will start in"

timeout 10

start chrome https://localhost:8082/swagger

echo "Project started and running";