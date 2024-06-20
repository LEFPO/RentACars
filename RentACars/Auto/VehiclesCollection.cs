using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Auto
{
    public class VehiclesCollection : ObservableCollection<Vehicle>
    {
        public VehiclesCollection() { }

        public bool AddItem(Vehicle ve)
        {
            if (!this.Any(VehiculeInTheCollection => VehiculeInTheCollection.Plate == ve.Plate))
            {
                this.Add(ve);
                return true;
            }
            else
            {
                return false;
                //Immat vehicule or vehicule model already in the collection and will not be added.
            }
        }
        /// <summary>
        /// Remove a specific vehicule in the collection (if ve exit) 
        /// </summary>
        /// <param name="ve"></param>
        public void DeleteItem(Vehicle ve)
        {
            if (this.Contains(ve))
            {
                this.Remove(ve);
            }
        }


        /// <summary>
        /// Sort Cars from de Véhicule Collection
        /// </summary>
        public List<Car> Cars => this.OfType<Car>().ToList();
        /// <summary>
        /// Sort Truck from Véhicule Collection
        /// </summary>
        public List<Truck> Trucks => this.OfType<Truck>().ToList();

        public bool AddVehicle(Vehicle ve)
        {
            if (this.Count == 0 || !this.Any(VehiculeInTheCollection => VehiculeInTheCollection.Id == ve.Id || (VehiculeInTheCollection.Chassis_number ==ve.Chassis_number)))
            {
                this.Add(ve);
                return true;
            }
            else
            {
                //id staff member or staff member LastName & FirstName already in the collection and will not be added.
                return false;
            }
        }

        /// <summary>
        /// Determine new next id (max + 1) for a manual AddItem
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            if (this != null && this.Count > 1)
            {
                return this.Max(ve => ve.Id) + 1;
            }
            else
            {
                return 1;
            }
        }

    }
}
