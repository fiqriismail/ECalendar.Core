using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace ECalendar.Web.Api.Brokers.Logings;

public class LogingBroker : ILogingBroker
{
    private ILogger<LogingBroker> logger;


    public LogingBroker(ILogger<LogingBroker> logger)
    {
        this.logger = logger;
    }

    public void LogInformation(string message)
    {
        this.logger.LogInformation(message);
    }

    public void LogTrace(string message)
    {
        this.logger.LogTrace(message);
    }

    public void LogDebug(string message)
    {
        this.logger.LogDebug(message);
    }

    public void LogWarning(string message)
    {
        this.logger.LogWarning(message);
    }

    public void LogError(Exception exception)
    {
        this.logger.LogError(exception, exception.Message);
    }

    public void LogCritical(Exception exception)
    {
        this.logger.LogCritical(exception, exception.Message);
    }
}