using System.Text.RegularExpressions;

namespace RentACars.Auto
{
    public class Cars : Vehicule
    {

        private string _chassis;
        private string _carburant;
        private string _motorisation;
        private string _permisrequis;
        private string _couleur;

        public Cars(string immat, string marque, string model, string year, bool dispo, string pictureName, string chassis, string carburant, string motorisation, string permisrequis, string couleur) : base(immat, marque, model, year, dispo, pictureName)
        {
            Chassis = chassis;
            Carburant = carburant;
            Motorisation = motorisation;
            Permisrequis = permisrequis;
            Couleur = couleur;

        }

        public string Chassis
        {
            get { return _chassis; }
            set
            {
                if (CheckChassis(value))
                {
                    _chassis = value;
                }
            }
        }
        public string Carburant
        {
            get { return _carburant; }
            set
            {
                if (CheckCarburant(value))
                {
                    _carburant = value;
                }
            }
        }
        public string Motorisation { get { return _motorisation; } set { _motorisation = value; } }
        public string Permisrequis
        {
            get { return _permisrequis; }
            set
            {
                if (CheckPermis(value))
                {
                    _permisrequis = value;
                }
            }
        }
        public string Couleur { get { return _couleur; } set { _couleur=value; } }

        private static bool CheckChassis(string chassis)
        {
            if (!string.IsNullOrEmpty(chassis))
            {
                chassis = chassis.ToUpper();
                if (Regex.IsMatch(chassis, @"^[A-HJ-NPR-Z0-9]{17}$"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private static bool CheckCarburant(string carburant)
        {
            carburant = carburant.ToUpper();
            switch (carburant)
            {
                case "ESSENCE":
                    return true;
                case "DIESEL":
                    return true;
                default:
                    return false;
            }
        }

        private static bool CheckPermis(string permis)
        {
            permis = permis.ToUpper();
            if (permis.Equals("B") && permis.Equals("C"))
            {
                return true;
            }
            return false;
        }

    }
}
