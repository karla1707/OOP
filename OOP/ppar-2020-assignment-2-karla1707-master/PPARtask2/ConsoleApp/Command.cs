using System;

namespace ConsoleApp
{
    internal delegate void CommandMethod();

    internal class Command
    {
        private CommandMethod methodToExecute;

        public string Description { get; set; }

        internal Command(CommandMethod commandMethod, string description)
        {
            methodToExecute = commandMethod;
            Description = description;
        }

        internal void Execute()
        {
            methodToExecute();
        }
    }
}