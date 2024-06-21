namespace RentACars.Auto
{
    public class Car : Vehicle
    {
        private string _driver_license;

        public Car(int id, string picture_name, string brand, string model, string color, string plate, bool available, string chassis_number, string motorization, string year_of_launch, double length, double width, int speed, string fuel, int power,double price_of_day, double vat_rate, string driver_license) : base(id, picture_name, brand, model, color, plate, available, chassis_number, motorization, year_of_launch, length, width, speed, fuel, power, price_of_day, vat_rate)
        {
            Driver_license = driver_license;
        }
        public string Driver_license
        {
            get
            {
                return _driver_license;
            }
            set
            {

                _driver_license = value;
                OnPropertyChanged(nameof(Driver_license));
            }            
        }        
    }
}
