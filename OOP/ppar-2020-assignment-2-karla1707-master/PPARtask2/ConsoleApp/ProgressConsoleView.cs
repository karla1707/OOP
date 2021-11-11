using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using backend.Database;
using Entity;

namespace ConsoleApp
{
    public class ProgressConsoleView
    {

        const string SEP_BAR = "========================";
        private IDBMapper dbMapper;
        private List<Type> types = new List<Type>();
        private List<Command> commands = new List<Command>();

        private Command showMenuCommand;
        private Command exitCommand;

      
        private Command currentCommand;


        public ProgressConsoleView(IDBMapper dbMapper)
        {
            this.dbMapper = dbMapper;

            InitializeCommandList();

            var userTypeA = Assembly.GetAssembly(typeof(User));
            var userTypes = userTypeA.GetTypes().Where(n => n.IsSubclassOf(typeof(User)));

            foreach (Type type in userTypes)
            {
                types.Add(type);
            }


        }

        private void InitializeCommandList()
        {
            showMenuCommand = new Command(ShowMenu, "Show main menu");
            commands.Add(showMenuCommand);

            commands.Add(new Command(CreateUser, "Create new user"));
            commands.Add(new Command(ViewAllUsers, "View a list of users"));
            commands.Add(new Command(ViewUserByLastname, "View user"));
            commands.Add(new Command(ShowMenu, "Show main menu"));

            exitCommand = new Command(ExitMenu, "Exit");
            commands.Add(exitCommand);



        }

        internal void StartConsole()
        {
            while(currentCommand != exitCommand)
            {

                showMenuCommand.Execute();
                currentCommand = GetUserCommand();
                currentCommand.Execute();
                Console.WriteLine("");

            }
        }

        private Command GetUserCommand()
        {

            bool validInput = false;
            int selectedOption = 0;

            while (!validInput)
            {
                selectedOption = Convert.ToInt32(Console.ReadLine());
                if(selectedOption <= commands.Count && selectedOption>0)
                {

                    validInput = true;
                }
                else
                {
                    Console.WriteLine("========================");

                    Console.WriteLine("You entered not existing command!");

                    Console.WriteLine("========================");

                    Console.WriteLine("");

                    StartConsole();
                }
            }



            Command selectedCommand =  commands.ElementAt(selectedOption-1);

            return selectedCommand;

        }

        private void ExitMenu()
        {
            Environment.Exit(-1);
        }

        private void ViewUserByLastname()
        {
            Console.WriteLine("Enter lastname to search: ");
            string lastName = Console.ReadLine();

            User user = dbMapper.GetUserByLastname(lastName);

            Console.WriteLine("ID: " + user.ID + "\n Firstname: " + user.FirstName + "\n Lastname: " + user.LastName);

        }

        private void ViewAllUsers()
        {
            List<User> allusers = dbMapper.GetAllUsers();

            Console.WriteLine(SEP_BAR);

            foreach(User u in allusers)
            {
                Console.WriteLine("ID: " + u.ID + "\n Firstname: " + u.FirstName + "\n Lastname: " + u.LastName);
            }

            Console.WriteLine(SEP_BAR);


        }

        private void CreateUser()
        {
            User newUser = null;
            bool validInput = false;
            string userTypeDes = "";
            int input =0;
            string propertyDes;
            Type userType;


            for (int i = 0; i < types.Count; i++)
            {
                userTypeDes += i + " " + types[i].Name + " ";
            }

            while(!validInput)
            {
                Console.WriteLine(userTypeDes);
                input = Convert.ToInt32(Console.ReadLine());
                if (input < types.Count && input>-1)
                {

                    validInput = true;
                }
            }


            userType = types[input];
            newUser = (User)Activator.CreateInstance(userType);

            foreach(PropertyInfo property in userType.GetProperties())
            {
                validInput = false;

                var description = (PropertyDetails[])property.GetCustomAttributes(typeof(PropertyDetails),false);
                propertyDes = (description.Length > 0 ? description[0].Description : property.Name);

                while(!validInput)
                {
                    try
                    {
                        Console.WriteLine("Enter " + propertyDes);
                        string userInput = Console.ReadLine();
                        property.SetValue(newUser, Convert.ChangeType(userInput, property.PropertyType), null);
                        validInput = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input, try again");

                    }
                }
            }

            dbMapper.AddUser(newUser);



        }

        private void ShowMenu()
        {
            Console.WriteLine(SEP_BAR);
            Console.WriteLine("MAIN MENU");
            Console.WriteLine(SEP_BAR);

            int i = 1;
            foreach(Command c in commands)
            {
                Console.WriteLine(i + " " + c.Description);
                i++;
            }

            Console.WriteLine(SEP_BAR);


        }
    }
}
