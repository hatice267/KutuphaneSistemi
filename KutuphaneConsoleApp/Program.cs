using KutuphaneConsoleApp.Library.Logger.Control;
using KutuphaneConsoleApp.Library.DbManager.Control;
using DotNetEnv;

Env.Load();
DatabaseManager db = new DatabaseManager();
Logger logger = new Logger(db);

bool devam = true;

while (devam)
{
    Console.WriteLine("\n--- KÜTÜPHANE VERİTABANI YÖNETİM PANELİ ---");
    Console.WriteLine("1) Veri Görüntüle (SELECT)");
    Console.WriteLine("2) Veri Ekle (INSERT)");
    Console.WriteLine("3) Veri Sil (DELETE)");
    Console.WriteLine("4) Çıkış");
    Console.WriteLine("5) Prosedür Çalıştır");
    Console.WriteLine("6) Fonksiyon Çalıştır");
    Console.Write("Seçiminiz: ");

    string? secim = Console.ReadLine();

    switch (secim)
    {
        case "1":
            Console.Write("Hangi tablodan veri görmek istersiniz? (örn: Kitaplar): ");
            string? tabloAdi = Console.ReadLine();
            await db.VeriGetirAsync($"SELECT * FROM {tabloAdi}");
            break;

        case "2":
            Console.Write("Çalıştırmak istediğiniz INSERT sorgusunu yazın: ");
            string? insertSorgu = Console.ReadLine();
            if (insertSorgu != null)
            {
                await db.SorguCalistirAsync(insertSorgu);
                logger.LogInfo($"INSERT sorgusu çalıştırıldı: {insertSorgu}");
            }
            break;

        case "3":
            Console.Write("Çalıştırmak istediğiniz DELETE sorgusunu yazın: ");
            string? deleteSorgu = Console.ReadLine();
            if (deleteSorgu != null)
                await db.SorguCalistirAsync(deleteSorgu);
            logger.LogInfo($"DELETE sorgusu çalıştırıldı: {deleteSorgu}");
            break;

        case "4":
            devam = false;
            break;

        case "5":
            Console.Write("Prosedür adını yazın: ");
            string? procAdi = Console.ReadLine();
            var procParametreler = new Dictionary<string, object>();
            Console.WriteLine("Parametreleri girin (bitirmek için boş bırakıp Enter'a basın):");
            while (true)
            {
                Console.Write("Parametre adı: ");
                string? pAdi = Console.ReadLine();
                if (string.IsNullOrEmpty(pAdi)) break;
                Console.Write("Parametre değeri: ");
                string? pDeger = Console.ReadLine();
                procParametreler.Add(pAdi, pDeger ?? "");
            }
            if (procAdi != null)
                await db.ExecuteProcedureAsync(procAdi, procParametreler);
            break;

        case "6":
            Console.Write("Fonksiyon adını yazın: ");
            string? funcAdi = Console.ReadLine();
            var funcParametreler = new Dictionary<string, object>();
            Console.WriteLine("Parametreleri girin (bitirmek için boş bırakıp Enter'a basın):");
            while (true)
            {
                Console.Write("Parametre adı: ");
                string? pAdi = Console.ReadLine();
                if (string.IsNullOrEmpty(pAdi)) break;
                Console.Write("Parametre değeri: ");
                string? pDeger = Console.ReadLine();
                funcParametreler.Add(pAdi, pDeger ?? "");
            }
            if (funcAdi != null)
                await db.ExecuteFunctionAsync(funcAdi, funcParametreler);
            break;

        default:
            Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
            break;
    }
}

record KitapEkleRequest(string KitapAdi, int YazarID, int YayineviID, int KategoriID, int StokAdedi);