using System;
namespace carDealer1
{

    public class Car : Vehicle
        {

            internal int NrOfSeats { get; set; }


            public Car(int id, double price, string regPlate, string model, int yearMade, int nrOfSeats,
                FuelType fuelType) : base(id, price, regPlate, model, yearMade,fuelType)
            {
                this.NrOfSeats = nrOfSeats;

            }

            public override void print()
            {

                String details = "\n Type of vehicle: Car \n " + this.ToString() + "\n Number of seats: " + this.NrOfSeats;

                Console.WriteLine(details);

             }
        }

}

