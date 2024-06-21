using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentACars.Auto;
using RentACars.Utilities.Interfaces;
using RentACars.View;

namespace RentACars.ViewModel
{
    public partial class VehiclePageViewModel : BaseViewModel
    {
        public VehiclePageViewModel(IDataAccess dataAccessService, IAlertService alertService) : base(alertService)
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
        /// <summary>
        /// Staff Member who will be displayed in the popup screen
        /// </summary>
        [ObservableProperty]
        private Vehicle vehiclePopupDisplayed;
        /// <summary>
        /// flag to know if user want to add a new staff member or consulting an existing one.
         /// </summary>
         [ObservableProperty]
        private bool isNewVehicleAction;
        /// <summary>
        /// Save changes, add, delete staffMemebers datas to the source.
        /// </summary>
        [RelayCommand()]
        public void SaveDatas()
        {
            if (dataAccess.UpdateVehicles(Vehicles))
            {
                alertService.ShowAlert("Sauvegarde", "Les données véhicule ont bien été sauvegardées");
 }
            else
            {
                alertService.ShowAlert("Sauvegarde erreur", "Une erreur est survenue lors de la sauvegarde");
            };
        }
        /// <summary>
        /// Show popup for a new staffMember edition
        /// command binded to the "Add new member" in the StaffMembersPage, will open the popup screen
         /// </summary>
         [RelayCommand()]
        public void ShowNewVehiclePopup()
        {
            //store information to know we will display the "Add New Member" button on the popup display
            IsNewVehicleAction = true;
            //get an id for the new StaffMember
            int nextId = Vehicles.GetNextId();
            //create a blank StaffMember
            VehiclePopupDisplayed = new Vehicle(nextId, "photo.jpg", "Marque", "Model", "Couleur", "1-AZE-123", true, "Numéro de Chassis", "Motorisation", "Année de mise en circulation", 2.5, 1.5, 150, "Diesel", 120, 125, 21.0);
            //create an instance of the NewStaffMemberPopup and give this viewModel
            var popup = new NewVehiclePopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);

        }
        /// <summary>
        /// Command binded to the "Add new Member" button in the pop up display
        /// </summary>
        [RelayCommand()]
        public void AddNewVehicle()
        {
            if (Vehicles.AddVehicle(VehiclePopupDisplayed))
            {
                alertService.ShowAlert("Ajout", "Le nouveau véhicule a bien été ajouté");
            }
            else
            {
                alertService.ShowAlert("Ajout erreur", "Une erreur est survenue lors de l'ajout");
            };
            //reset the property for a future choice.
            IsNewVehicleAction = false;
        }
        /// <summary>
        /// Get selection event from the listView
        /// Show popup for an existing staffMember read and edition
        /// </summary>
        [RelayCommand()]
        private void SelectVehicle(Vehicle ve)
        {
            //prevent to display "Add New Member button" on the popup display because it's an existing one
            IsNewVehicleAction = false;
            //affect the StaffMemberPopupDisplayed property to this current vehicle selected.
            VehiclePopupDisplayed = ve;
            //create an instance of the NewStaffMemberPopup and give this viewModel
            var popup = new NewVehiclePopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);
        }
        [RelayCommand]
        public async void NextPage()
        {
            await Shell.Current.GoToAsync("///RentalPage");
        }

        [RelayCommand]
        public async void DeleteVehicle()
        {
            if (VehicleSelection != null)
            {
                if (await alertService.ShowConfirmation("Supprimer", "Etes-vous sur de vouloir supprimer la selection?"))
                {
                    if (Vehicles.RemoveVehicle(VehicleSelection))
                    {
                        alertService.ShowAlert("Supprimer", "Le membre a bien été supprimé");
                    }
                    else
                    {
                        alertService.ShowAlert("Supprimer Erreur", "Une erreur est survenue lors de la suppression");
                    }
                }
                else
                {
                    alertService.ShowAlert("Erreur", "Vous n'avez selectionné personne");
                }
            }

        }//end class

    }//end clas
}

