using WorkerShifter.ViewModels.ShiftsViewModels;

namespace WorkerShifter.Views.Shifts;

public partial class ShiftDetailsPage : ContentPage
{
    ShiftDetailsPageViewModel _viewmodel;
    public ShiftDetailsPage()
	{
		InitializeComponent();
        _viewmodel = new ShiftDetailsPageViewModel();
        this.BindingContext = _viewmodel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewmodel.GetShifts();
    }
}