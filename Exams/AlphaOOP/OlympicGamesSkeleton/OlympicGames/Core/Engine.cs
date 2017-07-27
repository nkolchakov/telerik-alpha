using System;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        private static readonly IEngine instance = new Engine();

        private readonly ICommandParser parser;
        private readonly ICommandProcessor commandProcessor;
        private readonly IOlympicsFactory factory;
        private readonly IOlympicCommittee commitee;

        private const string Delimiter = "####################";

        private Engine()
        {
            this.parser = CommandParser.Instance;
            this.commandProcessor = CommandProcessor.Instance;
            this.factory = OlympicsFactory.Instance;
            this.commitee = OlympicCommittee.Instance;
        }

        public void Run()
        {
            string commandLine = null;

            while ((commandLine = Console.ReadLine()) != "end")
            {
                try
                {
                    var command = this.parser.ParseCommand(commandLine);
                    if (command != null)
                    {
                        //this.commandProcessor.Add(command);
                        this.commandProcessor.ProcessSingleCommand(command);
                        Console.WriteLine(Delimiter);
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    Console.WriteLine("ERROR: {0}", ex.Message);
                }
            }
        }

        public static IEngine Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
