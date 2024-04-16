using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentACars.Auto;
using RentACars.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(IDataAccess dataAccessService, IAlertService
        alertService) : base(alertService)
        {
            dataAccess = dataAccessService; // Instance qui vient du Singletone
            Vehicules = dataAccess.GetAllVehicules(); //get user's collection datas from chosen DataAccessSource(excel, csv, json...).
            //Tables = DataAccess.GetTables(); //get table's collection datas from chosen DataAccessSource (excel, csv, json...).
        }
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        public VehiculesCollection Vehicules { get; set; }

        [ObservableProperty]
        private Vehicule vehiculeUserSelection;


        [RelayCommand()]
        private async void ShowItemDetails()
        {
            if (VehiculeUserSelection != null)
            {
                await alertService.ShowAlert("Selection", $"Voitre choix :\n{ VehiculeUserSelection.Marque}, {VehiculeUserSelection.Model}\n " +
           

                $"{VehiculeUserSelection.Year}\n{VehiculeUserSelection.Dispo}\n{VehiculeUserSelection.Immat}.");
            }
            else
            {
                await alertService.ShowAlert("Error", "No item selection");
            }
        }
        [RelayCommand()]
        private async void TestBindingShowProperties()
        {
            await alertService.ShowAlert("Infos Entreprises ", $"En interne, les valeur des propriétés sont: " +
           

           $"\n{MainInfos.Name}\n{MainInfos.Address}\n{MainInfos.WebSite}\n{MainInfos.VatCode}")
           ;
        }
        [RelayCommand()]
        private async void TestBindingChangeProperties()
        {
            MainInfos.Name = "Agence de véhicule de location";
            MainInfos.Address = "10, rue de l'étang 7000 Mons";
            MainInfos.WebSite = "http://RentACars.com";
            MainInfos.VatCode = "BE 0202.239.951";
        }
    }
}
