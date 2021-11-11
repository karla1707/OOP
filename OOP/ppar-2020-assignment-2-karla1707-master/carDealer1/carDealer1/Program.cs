using System;
using System.Collections.Generic;

namespace carDealer1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //add a for loop
            VehicleManager vm = new VehicleManager();
            VehicleFactory vf = new VehicleFactory();



            while(true)
            {
                Console.WriteLine("To enter a vehicle press any key \n To do something else  enter 'q' ");

                String userInput = Console.ReadLine();

                if (userInput.Equals("q")) break;

                Vehicle v = vf.createVehicle();

                vm.addVehicle(v);

            }


            while (true)
            {



                Console.WriteLine("\n To get number of  vehicles press -  1 \n get all vehicles - 2 \n " +
                    "increase price - 3 \n get total value - 4 \n get the price of a specific vehicle (based on ID) - 5 \n " +
                    "search for a vehicle based on licence plate - 6 \n  search for a vehicle in a certain price range - 7 \n  To quit press - 8 \n");

                int command = Convert.ToInt32(Console.ReadLine());

                if (command == 8) break;

                switch (command)
                {
                    case 1:

                        Console.WriteLine(vm.getNrOfVehicles());
                        break;

                    case 2:

                        vm.printAll();
                        break;

                    case 3:

                        Console.WriteLine(" enter percentage to increase");
                        vm.increasePrices(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 4:

                        Console.WriteLine(vm.getPriceOfAll());
                        break;

                    case 5:

                        Console.WriteLine("Which vehicle price you want: enter id ");
                        double price = vm.getPriceByID(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine(price);
                        break;

                    case 6:

                        Console.WriteLine("Which vehicle price you want: enter registration plate ");
                        Vehicle result = vm.searchBylicencePlate(Console.ReadLine());
                        Console.WriteLine(result.Price);
                        break;

                    case 7:
                        Console.WriteLine("Enter minimum price:  ");
                        int min = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter maximum price:  ");
                        int max = Convert.ToInt32(Console.ReadLine());

                        List<Vehicle> list = vm.searchInPriceRange(min, max);

                        list.ForEach(v => v.print());

                        break;



                    default:
                        Console.WriteLine("Commant does not exist");
                        break;
                }
            }

        }
    }
}
