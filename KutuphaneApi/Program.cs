using Microsoft.AspNetCore.Mvc;
using DotNetEnv;
using KutuphaneConsoleApp.Library.DbManager.Control;
using KutuphaneConsoleApp.Library.DbManager;
using ILogger = KutuphaneConsoleApp.Library.Logger.Interface.ILogger;
using IDatabaseManager = KutuphaneConsoleApp.Library.DbManager.Interface.IDatabaseManager;
Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DatabaseManager>();
builder.Services.AddScoped<IDatabaseManager, DatabaseManager>();
builder.Services.AddScoped<ILogger, KutuphaneConsoleApp.Library.Logger.Control.Logger>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/api/kitaplar", async ([FromServices] DatabaseManager db, [FromServices] ILogger logger) =>
{
    var kitaplar = await db.VeriGetirListeAsync("SELECT * FROM Kitaplar");
    logger.LogInfo("Kitaplar listelendi.");
    return Results.Ok(kitaplar);
})
.WithName("GetKitaplar");

app.MapPost("/api/kitaplar", async ([FromServices] DatabaseManager db, [FromServices] ILogger logger, KitapEkleRequest yeniKitap) =>
{
    string sorgu = "INSERT INTO Kitaplar (KitapAdi, YazarID, YayineviID, KategoriID, StokAdedi) VALUES (@KitapAdi, @YazarID, @YayineviID, @KategoriID, @StokAdedi)";
    
    var parametreler = new Dictionary<string, object>
    {
        { "KitapAdi", yeniKitap.KitapAdi },
        { "YazarID", yeniKitap.YazarID },
        { "YayineviID", yeniKitap.YayineviID },
        { "KategoriID", yeniKitap.KategoriID },
        { "StokAdedi", yeniKitap.StokAdedi }
    };

    await db.SorguCalistirParametreliAsync(sorgu, parametreler);
    logger.LogInfo($"Yeni kitap eklendi: {yeniKitap.KitapAdi}");

    return Results.Created($"/api/kitaplar", yeniKitap);
})
.WithName("PostKitap");

app.MapPut("/api/kitaplar/{id}", async ([FromServices] DatabaseManager db, [FromServices] ILogger logger, int id, KitapEkleRequest guncelKitap) =>
{
    string sorgu = @"UPDATE Kitaplar 
                      SET KitapAdi = @KitapAdi, 
                          YazarID = @YazarID, 
                          YayineviID = @YayineviID, 
                          KategoriID = @KategoriID, 
                          StokAdedi = @StokAdedi 
                      WHERE KitapID = @KitapID";

    var parametreler = new Dictionary<string, object>
    {
        { "KitapAdi", guncelKitap.KitapAdi },
        { "YazarID", guncelKitap.YazarID },
        { "YayineviID", guncelKitap.YayineviID },
        { "KategoriID", guncelKitap.KategoriID },
        { "StokAdedi", guncelKitap.StokAdedi },
        { "KitapID", id }
    };

    await db.SorguCalistirParametreliAsync(sorgu, parametreler);
    logger.LogInfo($"Kitap güncellendi: ID={id}, YeniAd={guncelKitap.KitapAdi}");

    return Results.Ok(guncelKitap);
})
.WithName("PutKitap");

app.MapDelete("/api/kitaplar/{id}", async ([FromServices] DatabaseManager db, [FromServices] ILogger logger, int id) =>
{
    string sorgu = "DELETE FROM Kitaplar WHERE KitapID = @KitapID";

    var parametreler = new Dictionary<string, object>
    {
        { "KitapID", id }
    };

    await db.SorguCalistirParametreliAsync(sorgu, parametreler);
    logger.LogInfo($"Kitap silindi: ID={id}");

    return Results.NoContent();
})
.WithName("DeleteKitap");
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record KitapEkleRequest(string KitapAdi, int YazarID, int YayineviID, int KategoriID, int StokAdedi);