using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace RentACars.Auto
{
    public class Vehicule : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private static string[] ACCEPTED_PIC_EXT_FILES = { ".png", ".jpg" };

        private string _immat;
        private string _marque;
        private string _model;
        private string _year;
        private bool _dispo;
        private string _pictureName;



        public Vehicule(string immat, string marque, string model, string year, bool dispo, string pictureName)
        {
            Immat = immat;
            Marque = marque;
            Model = model;
            Year = year;
            Dispo = dispo;
            PictureName = pictureName;
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

        public string PictureName
        {
            get => _pictureName;
            set
            {
                if (CheckPicture(value))
                {
                    _pictureName = value;
                }
            }
        }

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
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
