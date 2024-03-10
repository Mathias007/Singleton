## ``Logger.cs`` - pseudocode
```class SingletonLogger:
    private static SingletonLogger _instance
    private List<string> logMessages

    private SingletonLogger():
        logMessages = new List<string>()

    public static SingletonLogger GetInstance():
        if _instance == null:
            _instance = new SingletonLogger()

        return _instance

    public void LogMessage(string message):
        logMessages.Add(message)

    public void PrintLogMessages():
        Output("Logged messages:")
        foreach message in logMessages:
            Output(message)

class Logger:
    static void Main(args):
        SingletonLogger logger1 = SingletonLogger.GetInstance()
        SingletonLogger logger2 = SingletonLogger.GetInstance()

        logger1.LogMessage("Test użycia 1. logera")
        logger2.LogMessage("Test użycia 2. logera")
        logger1.LogMessage("Message using 1st logger")
        logger2.LogMessage("Message using 2nd logger")

        if logger1 == logger2:
            Output("Singleton Logger works")
        else:
            Output("Singleton Logger failed")

        logger1.PrintLogMessages()
```

## ``Printer.cs`` - pseudocode
```
class PrintJob:
    private string content

    public PrintJob(content):
        Content = content

class PrintBuffer:
    private static PrintBuffer _instance
    private Queue<PrintJob> printQueue

    private PrintBuffer():
        printQueue = new Queue<PrintJob>()

    public static PrintBuffer GetInstance():
        if _instance == null:
            _instance = new PrintBuffer()

        return _instance

    public void AddPrintJob(job):
        printQueue.Enqueue(job)

    public void ExecutePrintJobs():
        while printQueue is not empty:
            job = printQueue.Dequeue()
            Output("Printing: " + job.Content)

class Printer:
    static void Main(args):
        PrintBuffer printBuffer1 = PrintBuffer.GetInstance()
        PrintBuffer printBuffer2 = PrintBuffer.GetInstance()

        if printBuffer1 == printBuffer2:
            Output("Singleton Print Buffer works")
        else:
            Output("Singleton Print Buffer failed")

        printBuffer1.AddPrintJob(new PrintJob("Document 1"))
        printBuffer1.AddPrintJob(new PrintJob("Document 2"))

        printBuffer1.ExecutePrintJobs()
```
