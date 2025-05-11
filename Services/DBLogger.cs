namespace BookOperations.Services;
public class DBLogger:ILoggerService
{
    public void Write(string message)
    {
        Console.WriteLine("[ConsoleLogger] - " + message);
    }  
}
    