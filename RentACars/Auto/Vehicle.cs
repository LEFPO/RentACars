using Microsoft.Maui.ApplicationModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace RentACars.Auto
{

    public class Vehicle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private static string[] ACCEPTED_PIC_EXT_FILES = { ".png", ".jpg" };
        private static string[] ACCEPTED_FUEL = { "Diesel", "Essence", "Electrique", "Hybride", "Hydrogène" };

        private int _id;
        private string _picture_name;
        private string _brand;
        private string _model;
        private string _color;
        private string _plate;
        private bool _available;
        private string _chassis_number;
        private string _motorization;
        private string _year_of_launch;
        private double _length;
        private double _width;
        private int _speed;
        private string _fuel;
        private int _power;
        private double _price_of_day;
        private double _vat_rate;
        private double _price_global;
        private int _quantity = 1 ;

        public Vehicle(int id, string picture_name, string brand, string model, string color, string plate, bool available, string chassis_number, string motorization, string year_of_launch, double length, double width, int speed, string fuel, int power, double price_of_day, double vat_rate)
        {
            Id = id;
            Picture_name = picture_name;
            Brand = brand;
            Model = model;
            Color = color;
            Plate = plate;
            Available = available;
            Chassis_number = chassis_number;
            Motorization = motorization;
            Year_of_launch = year_of_launch;
            Length = length;
            Width = width;
            Speed = speed;
            Fuel = fuel;
            Power = power;
            Price_of_day = price_of_day;
            Vat_rate = vat_rate;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Picture_name
        {
            get
            {
                return _picture_name;
            }
            set
            {
                if (CheckPicture(value))
                {
                    _picture_name = value;
                    OnPropertyChanged(nameof(Picture_name));
                }
            }
        }
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        public string Plate
        {
            get
            {
                return _plate;
            }
            set
            {
                if (CheckPlate(value))
                {
                    _plate = value;
                    OnPropertyChanged(nameof(Plate));
                }
            }
        }
        public bool Available
        {
            get
            {
                return _available;
            }
            set
            {
                _available = value;
                OnPropertyChanged(nameof(Available));
            }
        }
        public string Chassis_number
        {
            get
            {
                return _chassis_number;
            }
            set
            {                
                _chassis_number = value;
                OnPropertyChanged(nameof(Chassis_number));
            }
        }
        public string Motorization
        {
            get
            {
                return _motorization;
            }
            set
            {
                _motorization = value;
                OnPropertyChanged(nameof(Motorization));
            }
        }
        public string Year_of_launch
        {
            get
            {
                return _year_of_launch;
            }
            set
            {
                _year_of_launch = value;
                OnPropertyChanged(nameof(Year_of_launch));
            }
        }
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (CheckLenght(value))
                {
                    _length = value;
                    OnPropertyChanged(nameof(Length));
                }
                
            }
        }
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (CheckWidth(value))
                {
                    _width = value;
                    OnPropertyChanged(nameof(Width));
                }
                
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (CheckSpeed(value))
                {
                    _speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }
        public string Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                if (CheckFuel(value))
                {
                    _fuel = value;
                    OnPropertyChanged(nameof(Fuel));
                }
            }
        }
        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (CheckPower(value))
                {
                    _power = value;
                    OnPropertyChanged(nameof(Power));
                }
            }
        }

        public double Price_of_day
        {
            get
            {
                return _price_of_day;
            }
            set
            {
                if (CheckPrice_of_day(value))
                {
                    _price_of_day = value;
                    OnPropertyChanged(nameof(Price_of_day));
                }
            }
        }

        public double Vat_rate
        {
            get
            {
                return _vat_rate;
            }
            set
            {
                _vat_rate = value;
            }
        }
        public double Price_global
        {
            get
            {
                return _price_global;
            }
            set
            {
                _price_global = value;
                OnPropertyChanged(nameof(Price_global));
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                CalculatePrice();
                OnPropertyChanged(nameof(Quantity));
            }
        }


        public void CalculatePrice()
        {
            Price_global = ((Price_of_day * Quantity)*(1+(Vat_rate/100)));
        }

        private static bool CheckLenght(double lenght)
        {
            if (lenght <= 3.0 || lenght >= 10.0)
            {
                return false;
            }
            return true;
        }
        private static bool CheckWidth(double width)
        {
            if (width <= 0.5 || width >= 5.0)
            {
                return false;
            }
            return true;
        }

        static public bool CheckPicture(string path)
        {
            string pattern = "";
            long fileLength;


            foreach (string ext in ACCEPTED_PIC_EXT_FILES)
            {
                pattern += ext + "|";
            }
            pattern = pattern.Substring(0, pattern.Length - 1) + "$";//remove last "|" unuseful

            //test File extension 
            if (!Regex.IsMatch(path, pattern)) //pattern = ".png|.jpg$" -> test if end of string like .png or .jpg
            {
                //MessageBox.Show($"L'extension du fichier photo {path} n'est pas valide", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        static public bool CheckPower(int power)
        {
            if (power <= 1 || power >= 1000)
            {
                return false;
            }
            return true;
        }

        public static bool CheckChassisNumber(string chassisNumber)
        {
            string pattern = @"^[A-HJ-NPR-Z0-9]{3}[A-HJ-NPR-Z0-9]{5}[A-HJ-NPR-Z0-9]$";
            return Regex.IsMatch(chassisNumber, pattern);
        }

        static public bool CheckFuel(string fuel)
        {
            foreach (string f in ACCEPTED_FUEL)
            {
                if (fuel.Equals(f, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        static public bool CheckSpeed(int speed)
        {
            if (speed <= 1 || speed >= 500)
            {
                return false;
            }
            return true;
        }

        public static bool CheckYear_Of_Launch(string year_of_launch)
        {
            if (int.TryParse(year_of_launch, out int year))
            {
                int currentYear = DateTime.Now.Year;
                if (year >= 1950 && year <= currentYear)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckPlate(string plate)
        {
            if (!string.IsNullOrEmpty(plate))
            {
                plate = plate.ToUpper();
                if (Regex.IsMatch(plate, @"^[12]\d{0,1}-[A-Z]{3}-\d{3}$|^[12]\d{0,1}[A-Z]{3}\d{3}$"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool CheckPrice_of_day(double price)
        {
            if (price < 1 || price > 1000)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Methode PropertyChanged ↓↓↓
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
