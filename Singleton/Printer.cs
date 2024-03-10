using System;
using System.Collections.Generic;

namespace Singleton
{
    public class PrintJob
    {
        public string Content { get; }

        public PrintJob(string content)
        {
            Content = content;
        }
    }

    public sealed class PrintBuffer
    {
        private static PrintBuffer _instance;
        private Queue<PrintJob> printQueue;

        private PrintBuffer()
        {
            printQueue = new Queue<PrintJob>();
        }

        public static PrintBuffer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PrintBuffer();
            }

            return _instance;
        }

        public void AddPrintJob(PrintJob job)
        {
            printQueue.Enqueue(job);
        }

        public void ExecutePrintJobs()
        {
            while (printQueue.Count > 0)
            {
                var job = printQueue.Dequeue();
                Console.WriteLine("Printing: " + job.Content);
            }
        }
    }

    class Printer
    {
        static void Main(string[] args)
        {
            PrintBuffer printBuffer1 = PrintBuffer.GetInstance();
            PrintBuffer printBuffer2 = PrintBuffer.GetInstance();

            if (printBuffer1 == printBuffer2)
            {
                Console.WriteLine("Singleton Print Buffer works");
            }
            else
            {
                Console.WriteLine("Singleton Print Buffer failed");
            }

            printBuffer1.AddPrintJob(new PrintJob("Document 1"));
            printBuffer1.AddPrintJob(new PrintJob("Document 2"));

            printBuffer1.ExecutePrintJobs();
        }
    }
}
