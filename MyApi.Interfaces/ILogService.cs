namespace MyApi.Interfaces
{
    public interface ILogService
    {
        void Error(string message);
        void Warning(string message);
        void Info(string message);
    }
}