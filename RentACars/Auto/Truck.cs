using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Auto
{
    public class Truck : Vehicle
    {
        private double _height;
        private double _capacity;
        public Truck(int id, string picture_name, string brand, string model, string color, string plate, bool available, string chassis_number, string motorization, string year_of_launch, double length, double width, int speed, string fuel, int power, double price_of_day, double vat_rat, double height, double capacity) : base(id, picture_name, brand, model, color, plate, available, chassis_number, motorization, year_of_launch, length, width, speed, fuel, power, price_of_day, vat_rat)
        {
            Height = height;
            Capacity = capacity;
        }

        public double Height 
        { 
            get 
            { 
                return _height; 
            } 
            set
            {
                if (CheckHeigth(value))
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                }
            } 
        }
        public double Capacity 
        { 
            get 
            { 
                return _capacity; 
            } 
            set 
            {
                if (CheckCapacity(value))
                {
                    _capacity = value;
                    OnPropertyChanged(nameof(Capacity));
                }
            }
        }

        private static bool CheckHeigth(double longueur)
        {
            if (longueur <= 1.8 || longueur >= 2.2)
            {
                return false;
            }
            return true;
        }
        private static bool CheckCapacity(double capacity)
        {
            if (capacity <= 2.0 || capacity >= 10.0)
            {
                return false;
            }
            return true;
        }
    }
}
