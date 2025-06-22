using System;

public class LogManager
{
    private static LogManager? _sharedInstance;

    // Private constructor prevents external instantiation
    private LogManager()
    {
        Console.WriteLine("LogManager initialized.");
    }

    // Public method to access the single instance
    public static LogManager GetLogger()
    {
        if (_sharedInstance == null)
        {
            _sharedInstance = new LogManager();
        }

        return _sharedInstance;
    }

    // Method to print log messages
    public void WriteLog(string logText)
    {
        Console.WriteLine("Log Entry: " + logText);
    }
}

class AppStart
{
    static void Main(string[] args)
    {
        LogManager appLogger = LogManager.GetLogger();
        appLogger.WriteLog("Application started successfully.");

        LogManager secondLogger = LogManager.GetLogger();
        secondLogger.WriteLog("Another log message for the same logger.");

        if (appLogger == secondLogger)
        {
            Console.WriteLine("Same logger instance is being used.");
        }
        else
        {
            Console.WriteLine("Different logger instances exist.");
        }
    }
}
