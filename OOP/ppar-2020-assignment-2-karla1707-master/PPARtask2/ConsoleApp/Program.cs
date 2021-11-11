using System;
using backend.Database;
using Entity;

namespace ConsoleApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AbstractDBFactory dBFactory = AbstractDBFactory.CreateDBFactory();
            IDBMapper dbMapper = dBFactory.CreateDBMapper();

            ProgressConsoleView consoleView = new ProgressConsoleView(dbMapper);
            consoleView.StartConsole();
           
        }
    }
}
