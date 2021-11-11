using System;
namespace carDealer1
{
    public class VehicleFactory
    {

        private int id = 0;
        private double price;
        private int yearMade;
        private string registrationPlate, model;
        private FuelType fuelType;

        private void provideDetails()
        {

            id += 1;

            Console.WriteLine("Price? ");
            this.price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Year made? ");
            this.yearMade = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Registration plate? ");
            this.registrationPlate = Console.ReadLine();

            Console.WriteLine("Model? ");
            this.model = Console.ReadLine();

            Console.WriteLine("Fuel type? 1- Gasoline 2- Diesel ");
            FuelType fuelType = (FuelType)Convert.ToInt32(Console.ReadLine());




        }

        public Vehicle createVehicle()
        {

            Console.WriteLine("What is the type? CAR/TRUCK");
            string type = Console.ReadLine();

            if (type == null)
            {
                Console.WriteLine("Did not enter type");
                return null;
            }
            if (string.Equals(type, "car", StringComparison.OrdinalIgnoreCase)
)
            {
                this.provideDetails();
                Console.WriteLine("Number of seats? ");
                int seats = Convert.ToInt32(Console.ReadLine());

                Vehicle car = new Car(id, price, registrationPlate, model, yearMade, seats,fuelType);
                return car;

            }
            else if (string.Equals(type, "truck", StringComparison.OrdinalIgnoreCase)
)
            {
                //todo
                this.provideDetails();

                Console.WriteLine("Size of trailor?");
                double trailorSize = Convert.ToDouble(Console.ReadLine());

                Vehicle trailor = new Truck(id, price, registrationPlate, model, yearMade, trailorSize, fuelType);


                return trailor;
            }

            Console.WriteLine("Type does not exist;");
            return null;

        }
    }
}
