using System.Linq;
using Microsoft.Data.SqlClient;
using KutuphaneConsoleApp.Library.DbManager.Interface;

namespace KutuphaneConsoleApp.Library.DbManager.Control
{
    public class DatabaseManager : IDatabaseManager
    {
        private string baglantiCumlesi = 
    $"Server={Environment.GetEnvironmentVariable("DB_SERVER")};" +
    $"Database={Environment.GetEnvironmentVariable("DB_DATABASE")};" +
    "Trusted_Connection=True;TrustServerCertificate=True;";

       public async Task SorguCalistirAsync(string sorgu)
{
        using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
    {
         await baglanti.OpenAsync();                          // asenkron bekleme
         SqlCommand komut = new SqlCommand(sorgu, baglanti);
         int etkilenenSatir = await komut.ExecuteNonQueryAsync();  // asenkron bekleme
         Console.WriteLine($"İşlem tamamlandı. Etkilenen satır sayısı: {etkilenenSatir}");
    }
}
public async Task VeriGetirAsync(string sorgu)
{
    using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
    {
        await baglanti.OpenAsync();
        SqlCommand komut = new SqlCommand(sorgu, baglanti);
        SqlDataReader okuyucu = await komut.ExecuteReaderAsync();

        while (await okuyucu.ReadAsync())
        {
            for (int i = 0; i < okuyucu.FieldCount; i++)
            {
                Console.Write(okuyucu.GetName(i) + ": " + okuyucu[i] + "  ");
            }
            Console.WriteLine();
        }
    }
}
    
public async Task ExecuteProcedureAsync(string procedureAdi, Dictionary<string, object> parametreler)
{
    using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
    {
        await baglanti.OpenAsync();
        SqlCommand komut = new SqlCommand(procedureAdi, baglanti);
        komut.CommandType = System.Data.CommandType.StoredProcedure;

        foreach (var parametre in parametreler)
        {
            komut.Parameters.AddWithValue("@" + parametre.Key, parametre.Value);
        }

        SqlDataReader okuyucu = await komut.ExecuteReaderAsync();

        if (okuyucu.HasRows)
        {
            while (await okuyucu.ReadAsync())
            {
                for (int i = 0; i < okuyucu.FieldCount; i++)
                {
                    Console.Write(okuyucu.GetName(i) + ": " + okuyucu[i] + "  ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Prosedür çalıştırıldı, veri döndürmedi.");
        }
    }
}

public async Task ExecuteFunctionAsync(string functionAdi, Dictionary<string, object> parametreler)
{
    using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
    {
        await baglanti.OpenAsync();

        // Parametre isimlerini @p1, @p2 şeklinde SQL sorgusuna ekliyoruz
        string parametreListesi = string.Join(", ", parametreler.Keys.Select(k => "@" + k));
        string sorgu = $"SELECT dbo.{functionAdi}({parametreListesi})";

        SqlCommand komut = new SqlCommand(sorgu, baglanti);

        foreach (var parametre in parametreler)
        {
            komut.Parameters.AddWithValue("@" + parametre.Key, parametre.Value);
        }

        object? sonuc = await komut.ExecuteScalarAsync();
        Console.WriteLine($"Fonksiyon sonucu: {sonuc}");
    }
}
public async Task<List<Dictionary<string, object>>> VeriGetirListeAsync(string sorgu)
{
    var sonuclar = new List<Dictionary<string, object>>();

    using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
    {
        await baglanti.OpenAsync();
        SqlCommand komut = new SqlCommand(sorgu, baglanti);
        SqlDataReader okuyucu = await komut.ExecuteReaderAsync();

        while (await okuyucu.ReadAsync())
        {
            var satir = new Dictionary<string, object>();
            for (int i = 0; i < okuyucu.FieldCount; i++)
            {
                satir[okuyucu.GetName(i)] = okuyucu[i];
            }
            sonuclar.Add(satir);
        }
    }

    return sonuclar;
}
public async Task SorguCalistirParametreliAsync(string sorgu, Dictionary<string, object> parametreler)
{
    using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
    {
        await baglanti.OpenAsync();
        SqlCommand komut = new SqlCommand(sorgu, baglanti);

        foreach (var parametre in parametreler)
        {
            komut.Parameters.AddWithValue("@" + parametre.Key, parametre.Value);
        }

        int etkilenenSatir = await komut.ExecuteNonQueryAsync();
        Console.WriteLine($"İşlem tamamlandı. Etkilenen satır sayısı: {etkilenenSatir}");
    }
}
    }
}