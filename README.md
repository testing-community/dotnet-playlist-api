# dotnet-playlist-api

This is an API to save playlists and songs associated to it. It is intended to be use for QA workshops using dotnet projects.

## How to run API locally
It is recommended to open, and run this project on Visual Studio (2022a at least). Even if it is not mandatory, the instructions will be made assuming that the IDE used is Visual Studio. Feel free to use other IDEs and investigate other ways to configure the project.

### Clone and open project

1. Clone or download the repository (git clone https://github.com/testing-community/dotnet-playlist-api.git)
1. Open the project on Visual Studio (File -> Open -> Project/Solution -> PlaylistsWorkshop.sln)

### Setup Database and Run API
The project uses a SQLite database to persist data. As it is a local database, first it needs to be generated

1. Open the Package Manager Console from Visual Studio (View -> Other Windows -> Package Manager Console)
1. On the PCM, type `Install-Package Microsoft.EntityFrameworkCore.Tools` to install entity framework tools. (To more information about the command, visit https://docs.microsoft.com/en-us/ef/core/cli/powershell)
1. On the PCM, type `Update-Database` to setup the local database based on the migration files on the `Migrations Folder`. (To more information about migrations, visit https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/)
1. On Visual Studio, press `F5` to run the Application in Debug Mode, or `Ctrl + F5` to start whithout debugging. This will open a swagger page on https://localhost:7019/swagger/index.html. Now you can start to use the API Locally :)
