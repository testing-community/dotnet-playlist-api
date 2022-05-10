using Microsoft.EntityFrameworkCore;
using PlaylistsWorkshop.Model;
using System.Text.Json.Serialization;
using PlaylistsWorkshop.Repositories;
using PlaylistsWorkshop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = System.IO.Path.Join(path, "playlistapi.db");

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<PlaylistWorkshopContext>(opt =>
    opt.UseSqlite($"Data Source={dbPath}"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlaylistsRepository, PlaylistsRepository>()
    .AddScoped<IPlaylistsService, PlaylistsService>();

builder.Services.AddScoped<ISongsRepository, SongsRepository>()
    .AddScoped<ISongsService, SongsService>();

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
