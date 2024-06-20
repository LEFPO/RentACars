using RentACars.ViewModel;

namespace RentACars.View;

public partial class RentalPage : ContentPage
{
    public RentalPage(RentalPageViewModel RentalPageVM)
    {
        BindingContext = RentalPageVM;
        InitializeComponent();
    }
}