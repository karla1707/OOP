using System;
using System.Collections.Generic;

namespace carDealer1
{
    public class VehicleManager
    {
        List<Vehicle> vehicles;

        public VehicleManager()
        {
            vehicles = new List<Vehicle>();
        }

        public void printAll() {

            vehicles.ForEach(v => v.print());

        }

        public void addVehicle(Vehicle v) {

            vehicles.Add(v);

        }

        public int getNrOfVehicles() {

            return vehicles.Count;
        }

        public double getPriceOfAll() {

            double sum = 0;
            vehicles.ForEach(v => sum += v.Price);
            return sum;

        }
        public double getPriceByID(int id) {

            return vehicles.Find(v => v.Id == id).Price;

        }
        public void increasePrices(int percentage){


            vehicles.ForEach(v => v.Price = v.Price + (v.Price * percentage / 100));


        }
        public Vehicle searchBylicencePlate(string registrationPlate){


            return vehicles.Find(v => v.RegistrationPlate.Equals(registrationPlate));

        }
        public List<Vehicle> searchInPriceRange(double low, double high)
        {
           
            return vehicles.FindAll(v => v.Price > low && v.Price < high);
        }








    }
}
