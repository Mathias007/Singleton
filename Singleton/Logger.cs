using System;
using System.Collections.Generic;

namespace ProjectPatterns
{
    public sealed class SingletonLogger
    {
        private static SingletonLogger _instance;
        private List<string> logMessages;

        private SingletonLogger()
        {
            logMessages = new List<string>();
        }

        public static SingletonLogger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SingletonLogger();
            }

            return _instance;
        }

        public void LogMessage(string message)
        {
            logMessages.Add(message);
        }

        public void PrintLogMessages()
        {
            Console.WriteLine("Logged messages:");
            foreach (var message in logMessages)
            {
                Console.WriteLine(message);
            }
        }
    }

    class Logger
    {
        static void Main(string[] args)
        {
            SingletonLogger logger1 = SingletonLogger.GetInstance();
            SingletonLogger logger2 = SingletonLogger.GetInstance();

            logger1.LogMessage("Test użycia 1. logera");
            logger2.LogMessage("Test użycia 2. logera");
            logger1.LogMessage("Message using 1st logger");
            logger2.LogMessage("Message using 2nd logger");

            if (logger1 == logger2)
            {
                Console.WriteLine("Singleton Logger works");
            }
            else
            {
                Console.WriteLine("Singleton Logger failed");
            }

            logger1.PrintLogMessages();
        }
    }
}
