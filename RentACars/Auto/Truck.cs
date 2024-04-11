namespace RentACars.Auto
{
    public class Truck : Vehicule
    {
        private double _hauteur;
        private double _largeur;
        private double _longueur;
        private double _capacite;

        public Truck(string immat, string marque, string model, string year, bool dispo, double hauteur, double largeur, double longueur, double capacite) : base(immat, marque, model, year, dispo)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Longueur = longueur;
            Capacite = capacite;
        }

        public double Hauteur
        {
            get { return _hauteur; }
            set
            {
                if (CheckHauteur(value))
                {
                    _hauteur = value;
                }
            }
        }
        public double Largeur
        {
            get { return _largeur; }
            set
            {
                if (CheckLargeur(value))
                {
                    _largeur = value;
                }
            }
        }
        public double Longueur
        {
            get { return _longueur; }
            set
            {
                if (CheckLongueur(value))
                {
                    _longueur = value;
                }
            }
        }
        public double Capacite
        {
            get { return _capacite; }
            set
            {
                if (CheckCapacite(value))
                {
                    _capacite = value;
                }
            }
        }

        private static bool CheckHauteur(double hauteur)
        {
            if (hauteur < 1.8 || hauteur > 2.2)
            {
                return false;
            }
            return true;
        }
        private static bool CheckLargeur(double largeur)
        {
            if (largeur < 1.7 || largeur > 2.0)
            {
                return false;
            }
            return true;
        }
        private static bool CheckLongueur(double longueur)
        {
            if (longueur < 4.5 || longueur > 6.5)
            {
                return false;
            }
            return true;
        }
        private static bool CheckCapacite(double capacite)
        {
            if (capacite < 2.0 || capacite > 10.0)
            {
                return false;
            }
            return true;
        }
    }
}
