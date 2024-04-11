using System.Text.RegularExpressions;

namespace RentACars.Auto
{
    public class Vehicule
    {
        private string _immat;
        private string _marque;
        private string _model;
        private string _year;
        private bool _dispo;

        public Vehicule(string immat, string marque, string model, string year, bool dispo)
        {
            Immat = immat;
            Marque = marque;
            Model = model;
            Year = year;
            Dispo = dispo;
        }

        public string Immat
        {
            get
            {
                return _immat;
            }
            set
            {
                if (CheckImmat(value))
                {
                    _immat = value;
                }
            }
        }
        public string Marque { get { return _marque; } set { _marque = value; } }
        public string Model { get { return _model; } set { _model = value; } }
        public string Year { get { return _year; } set 
            { 
                if (CheckYear(value))
                { 
                    _year = value; 
                } 
            } 
        }
        public bool Dispo { get { return _dispo; } set { _dispo = value; } }

        private static bool CheckImmat(string immat)
        {

            if (!string.IsNullOrEmpty(immat))
            {
                immat = immat.ToUpper();
                if (Regex.IsMatch(immat, @"^[12]\d{0,1}-[A-Z]{3}-\d{3}$|^[12]\d{0,1}[A-Z]{3}\d{3}$"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        private static bool CheckYear(string year)
        {
            if (!string.IsNullOrEmpty(year))
            {
                int yearInt = Convert.ToInt32(year);
                if (yearInt < 1950 || yearInt > 2024)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

    }
}
