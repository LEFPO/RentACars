using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Maui.Controls;
using RentACars.Auto;
using RentACars.Utilities.DataAccess;
using RentACars.Utilities.Interfaces;
using RentACars.Utilities.Services;
using RentACars.View;
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
            Vehicles = dataAccess.GetAllVehicles(); //get user's collection datas from chosen DataAccessSource(excel, csv, json...).
            //Tables = DataAccess.GetTables(); //get table's collection datas from chosen DataAccessSource (excel, csv, json...).
        }
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        public VehiclesCollection Vehicles { get; set; }

        [ObservableProperty]
        private Vehicle vehicleUserSelection;

        [ObservableProperty]
        public string log;

        [ObservableProperty]
        public string pass;


        [RelayCommand()]
        private async void ShowItemDetails()
        {
            if (VehicleUserSelection != null)
            {
                await alertService.ShowAlert("Selection", $"Voitre choix :\n{ VehicleUserSelection.Brand}, {VehicleUserSelection.Model}\n " +
           

                $"{VehicleUserSelection.Year_of_launch}\n{VehicleUserSelection.Available}\n{VehicleUserSelection.Plate}.");
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

        [RelayCommand]
        public void NextPage()
        {
            if (!Log.IsNullOrEmpty() && !Pass.IsNullOrEmpty())
            {
                if (dataAccess.CheckLog(Log, Pass))
                {
                    Shell.Current.GoToAsync("///VehiclePage");
                }
                else
                {
                    AlertServiceDisplay alertService = new AlertServiceDisplay();
                    alertService.ShowAlert("Désoler", "Les données que vous avez entré son incorrect");
                }
            }else
            {
                AlertServiceDisplay alertService = new AlertServiceDisplay();
                alertService.ShowAlert("Désoler", "Rentrer des données");
            }
       
        }

        [RelayCommand()]
        private async void NewCompte()
        {
            AlertServiceDisplay alertService = new AlertServiceDisplay();
            await alertService.ShowAlert("Désoler", "Cette fonctionnalité est en cours de création");
        }
    }
}
