using System;
namespace carDealer1
{
    public abstract class Vehicle
    {
        internal int Id { get; set; }
        internal int  YearMade { get; set; }
        internal double Price { get; set; }
        internal string RegistrationPlate { get; set; }
        internal string Model { get; set; }
        public FuelType fuelType;
 



        public Vehicle(int ID, double Price, string registrationPlate, string model, int yearMade,FuelType fuelType)
        {
            this.Id = ID;
            this.Price = Price;
            this.RegistrationPlate = registrationPlate;
            this.Model = model;
            this.YearMade = yearMade;
            this.fuelType = fuelType;

        }

       
        public override string ToString()
        {
            return "Vehicle id:  " + Id + "\n Year made: " + YearMade + "\n Price: " + Price +
                "\n Registration plate: "  + RegistrationPlate +  "\n Model: " + Model + "\n Fuel type: " + fuelType ;
        }

        public abstract void  print();


    }

}
