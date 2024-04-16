using RentACars.Auto;
using RentACars.Utilities.DataAccess.Files;
using RentACars.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentACars.Utilities.DataAccess
{
    class DataAccessCsvFiles : DataAccess, IDataAccess
    {
        public DataAccessCsvFiles(string filePath) : base(filePath) { }
        /// <summary>
        /// Constructor associated with a datafileManager, it contains path to a config text file
        /// wich contains path to csv files
        /// </summary>
        /// <param name="dfm"></param>
        public DataAccessCsvFiles(DataFilesManager dfm) : base(dfm) { }

        public static Vehicule GetVehicule(string csvline)
        {
            string[] fields = csvline.Split(';');
            switch (fields[0])
            {
            case "CARS":
                return new Cars(immat: fields[1], marque: fields[2], model: fields[3], year: fields[4], dispo: bool.Parse(fields[5]), chassis: fields[6], carburant: fields[7], motorisation: fields[8], permisrequis: fields[9], couleur: fields[10], pictureName: fields[11]);
            case "TRUCKS":
                return new Truck(immat: fields[1], marque: fields[2], model: fields[3], year: fields[4], dispo: bool.Parse(fields[5]), pictureName: fields[11], hauteur: double.Parse(fields[12]), largeur: double.Parse(fields[13]), longueur: double.Parse(fields[14]),capacite : double.Parse(fields[15]));
            default:
                return null;
            }
        }
        public override VehiculesCollection GetAllVehicules()
        {
            List<string> listToRead = new List<string>();
            VehiculesCollection vehicule = new VehiculesCollection();
            string temp = DataFilesManager.DataFiles.GetFilePathByCodeFunction("VEHICULE");
            
            AccessPath = temp;
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Vehicule ve = GetVehicule(s);
                    vehicule.AddItem(ve);
                }
                return vehicule;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }

        
    }
}
