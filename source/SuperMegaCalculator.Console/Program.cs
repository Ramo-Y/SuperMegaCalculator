namespace SuperMegaCalculator.Console
{
    using System;

    internal static class Program
    {
        internal static void Main()
        {
            Start();
        }

        private static void Start()
        {
            try
            {
                var startUpManager = new StartUpManager();
                startUpManager.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Oh shit! Something went wrong!");
                Console.WriteLine($"Exception: {exception}");
            }
            finally
            {
                Console.WriteLine("Application shutting down...");
                Console.WriteLine($"ExitCode = {Environment.ExitCode}");
            }
        }
    }
}