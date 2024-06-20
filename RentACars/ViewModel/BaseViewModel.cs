using CommunityToolkit.Mvvm.ComponentModel;
using RentACars.Model;
using RentACars.Utilities.Interfaces;

namespace RentACars.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel(IAlertService alertService, string restaurantName = "My restaurant")
        {
            RestaurantName = restaurantName;
            this.alertService = alertService;
            MainInfos = new MainInformations("RentACars", "10, rue de l'étang 7000 Mons", "BE 0563.191.043", "http://RentACars.be");

        }
        public MainInformations MainInfos { get; set; }


        protected IAlertService alertService;

        public string RestaurantName { get; set; }
        public DateTime Today { get; } = DateTime.Now;
        public string TodayDate => Today.Date.ToString("d-M-yyyy");


    }
}
