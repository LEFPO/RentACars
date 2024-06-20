using RentACars.ViewModel;

namespace RentACars.View;

public partial class VehiclePage : ContentPage
{
	public VehiclePage(VehiclePageViewModel vehiclePageVM)
	{
		BindingContext = vehiclePageVM;
		InitializeComponent();
	}
}