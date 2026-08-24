namespace KutuphaneConsoleApp.Library.DbManager.Interface
{
    public interface IDatabaseManager
    {
        Task SorguCalistirAsync(string sorgu);
        Task VeriGetirAsync(string sorgu);
        Task ExecuteProcedureAsync(string procedureAdi, Dictionary<string, object> parametreler);
        Task ExecuteFunctionAsync(string functionAdi, Dictionary<string, object> parametreler);
        Task<List<Dictionary<string, object>>> VeriGetirListeAsync(string sorgu);
        Task SorguCalistirParametreliAsync(string sorgu, Dictionary<string, object> parametreler);
    }
}