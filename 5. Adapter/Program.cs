using System;

interface IOldLogger
{
    void LogMessage(string msg);
}

class OldLogger : IOldLogger
{
    public void LogMessage(string msg)
    {
        Console.WriteLine("Old Logger: " + msg);
    }
}

class NewLogger
{
    public void Log(string message)
    {
        Console.WriteLine("New Logger: " + message);
    }
}

class NewLoggerAdapter : IOldLogger
{
    private NewLogger newLogger;

    public NewLoggerAdapter(NewLogger newLogger)
    {
        this.newLogger = newLogger;
    }

    public void LogMessage(string msg)
    {
        newLogger.Log(msg);
    }
}

class Program
{
    static void Main()
    {
        IOldLogger oldLogger = new OldLogger();
        oldLogger.LogMessage("This is a message using the old logger.");

        NewLogger newLogger = new NewLogger();
        IOldLogger adaptedLogger = new NewLoggerAdapter(newLogger);
        adaptedLogger.LogMessage("This is a message using the new logger through adapter.");
    }
}
