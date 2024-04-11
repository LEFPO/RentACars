﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using RentACars.Utilities.Interfaces;
using RentACars.Utilities.DataAccess.Files;
using RentACars.Auto;


namespace RentACars.Utilities.DataAccess
{
    public class DataAccessJsonFile : DataAccess, IDataAccess
    {

        public DataAccessJsonFile(string filePath) : base(filePath)
        { 
        }
        public DataAccessJsonFile(string filePath, string[] extensions) : base(filePath, extensions)
        {

        }

        public DataAccessJsonFile(DataFilesManager dfm) :base(dfm)
        {
            
        }
        /// <summary>
        /// retrieve all items object in an ItemCollection from json File Code ITEMS.
        /// </summary>
        /// <returns></returns>
        public override VehiculesCollection GetAllVehicules()
        {

            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("VEHICULE");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                VehiculesCollection? its = new VehiculesCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                its = JsonConvert.DeserializeObject<VehiculesCollection>(jsonFile, settings);
                return its;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }//end GetAllItems

        /// <summary>
        /// update json source file from the item collection
        /// </summary>
        /// <param name="uc"></param>
        public  void UpdateAllVehiculesDatas(VehiculesCollection ve)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("VEHICULE");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(ve, Formatting.Indented, settings);

                File.WriteAllText(AccessPath, json);
            }
            else
            {
                Console.WriteLine("UpdateAllUsersDatas error can't update datasource file");
            }
        }

                                
    }
}