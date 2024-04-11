﻿using RentACars.Auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentACars.Utilities.Interfaces
{
    internal interface IDataAccess
    {
        /// <summary>
        /// Access string to the external source (file path, connection string ...)
        /// </summary>
        string AccessPath
        {
            get;
            set;
        }
        /// <summary>
        /// retrieve items informations from the external source
        /// </summary>
        /// <returns>an ItemsCollection </returns>
        VehiculesCollection GetAllVehicules();
        
      

    }
}