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

        public static Vehicle GetVehicule(string csvline)
        {
            string[] fields = csvline.Split(';');
            switch (fields[0])
            {
            case "CARS":
                return new Car(id: int.Parse(fields[1]),picture_name: fields[2], brand: fields[3],model: fields[4], color: fields[5], plate: fields[6], available: bool.Parse(fields[7]), chassis_number: fields[8], motorization: fields[9], year_of_launch: fields[10], length: double.Parse(fields[11]), width: double.Parse(fields[12]), speed: int.Parse(fields[13]), fuel: fields[14],power: int.Parse(fields[15]), price_of_day: double.Parse(fields[16]), vat_rate: double.Parse(fields[17]), driver_license: fields[18]);
            case "TRUCKS":
                return new Truck(id: int.Parse(fields[1]), picture_name: fields[2], brand: fields[3], model: fields[4], color: fields[5], plate: fields[6], available: bool.Parse(fields[7]), chassis_number: fields[8], motorization: fields[9], year_of_launch: fields[10], length: double.Parse(fields[11]), width: double.Parse(fields[12]), speed: int.Parse(fields[13]), fuel: fields[14], power: int.Parse(fields[15]), price_of_day: double.Parse(fields[16]), vat_rat: double.Parse(fields[17]), height: double.Parse(fields[19]), capacity: double.Parse(fields[20]));
            default:
                return null;
            }
        }
        public override VehiclesCollection GetAllVehicles()
        {
            List<string> listToRead = new List<string>();
            VehiclesCollection vehicule = new VehiclesCollection();
            string temp = DataFilesManager.DataFiles.GetFilePathByCodeFunction("VEHICLE");
            
            AccessPath = temp;
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Vehicle ve = GetVehicule(s);
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

        public override bool UpdateVehicles(VehiclesCollection vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
