using System;
namespace carDealer1
{
    
        public class Truck : Vehicle
        {

            internal double TrailorSize { get; set;  }


            public Truck(int id, double price, string regPlate, string model, int yearMade, double sizeOfTrailor, FuelType fuelType) : base(id, price, regPlate, model, yearMade, fuelType)
            {
                this.TrailorSize = sizeOfTrailor;

            }

            public override void print()
            {
                 String details = "\n Type of vehicle: Truck \n " + this.ToString() + "\n Trailor size: " + this.TrailorSize;

                 Console.WriteLine(details);


            }


        }
}

