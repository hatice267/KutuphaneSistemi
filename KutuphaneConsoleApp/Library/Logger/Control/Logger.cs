using ILogger = KutuphaneConsoleApp.Library.Logger.Interface.ILogger;
using KutuphaneConsoleApp.Library.DbManager.Interface;

namespace KutuphaneConsoleApp.Library.Logger.Control
{
    public class Logger : ILogger
    {
        private readonly IDatabaseManager dbManager;

        public Logger(IDatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public void LogInfo(string mesaj) => Kaydet("INFO", mesaj);
        public void LogWarning(string mesaj) => Kaydet("WARNING", mesaj);
        public void LogError(string mesaj) => Kaydet("ERROR", mesaj);

        private void Kaydet(string seviye, string mesaj)
        {
            string sorgu = $"INSERT INTO Logs (Tarih, Seviye, Mesaj) VALUES (GETDATE(), '{seviye}', '{mesaj.Replace("'", "''")}')";
            dbManager.SorguCalistirAsync(sorgu).Wait();
            Console.WriteLine($"[{seviye}] {mesaj}");
        }
    }
}