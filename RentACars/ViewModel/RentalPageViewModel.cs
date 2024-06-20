using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentACars.Auto;
using RentACars.Utilities.Interfaces;
using RentACars.View;

namespace RentACars.ViewModel
{
    public partial class RentalPageViewModel: BaseViewModel
    {
        public RentalPageViewModel(IDataAccess dataAccessService, IAlertService alertService) : base(alertService)
        {
            dataAccess = dataAccessService;
            Vehicles = dataAccess.GetAllVehicles(); //get user's collection datas from chosen DataAccessSource(excel, csv, json...). 
        }
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        /// <summary>
        /// collection of all Vehicles
        /// </summary>
        public VehiclesCollection Vehicles { get; set; }
        /// <summary>
        /// Staff Member selected in the listview
        /// </summary>
        [ObservableProperty]
        private Vehicle vehicleSelection;
    }//end clas
}
