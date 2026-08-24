namespace KutuphaneConsoleApp.Library.Logger.Interface
{
    public interface ILogger
    {
        void LogInfo(String mesaj);
        void LogWarning(String mesaj);
        void LogError(String mesaj);
    }
}