using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Auto
{
    public class VehiculesCollection : ObservableCollection<Vehicule>
    {
        public VehiculesCollection() { }

        public new void AddItem(Vehicule ve)
        {
            if (!this.Any(VehiculeInTheCollection => VehiculeInTheCollection.Immat == ve.Immat || VehiculeInTheCollection.Model == ve.Model))
            {
                this.Add(ve);
            }
            else
            {
                //Immat vehicule or vehicule model already in the collection and will not be added.
            }
        }
        /// <summary>
        /// Remove a specific vehicule in the collection (if ve exit) 
        /// </summary>
        /// <param name="ve"></param>
        public void DeleteItem(Vehicule ve)
        {
            if (this.Contains(ve))
            {
                this.Remove(ve);
            }
        }


        /// <summary>
        /// Sort Cars from de Véhicule Collection
        /// </summary>
        public List<Cars> Cars => this.OfType<Cars>().ToList();
        /// <summary>
        /// Sort Truck from Véhicule Collection
        /// </summary>
        public List<Truck> Trucks => this.OfType<Truck>().ToList();

    }
}
