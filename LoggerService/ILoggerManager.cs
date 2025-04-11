namespace LoggerService
{
    public interface ILoggerManager
    {
        void logInfo(string message);
        void logWarn(string message);
        void logDebug(string message);
        void logError(string message, Exception ex);
    }
}
