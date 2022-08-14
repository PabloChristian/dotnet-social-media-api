dotnet clean

dotnet restore

dotnet build

dotnet tool install --global dotnet-ef

dotnet ef database update --startup-project .\Posterr.Api

start dotnet watch run --project .\Posterr.Api

echo "Project started and running";