using CommunityToolkit.Maui.Views;
using RentACars.ViewModel;

namespace RentACars.View;

public partial class NewVehiclePopup : Popup
{
    public NewVehiclePopup(VehiclePageViewModel vehiclePageVM)
    {
        BindingContext = vehiclePageVM;
        InitializeComponent();
    }
    private void buttonClose_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}
