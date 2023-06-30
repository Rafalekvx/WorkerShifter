using WorkerShifter.ViewModels.ShiftsViewModels;

namespace WorkerShifter.Views.Shifts;

public partial class ShiftUpdatePage : ContentPage
{
    ShiftUpdatePageViewModel _viewmodel;
    public ShiftUpdatePage()
	{
		InitializeComponent();
        _viewmodel = new ShiftUpdatePageViewModel();
        this.BindingContext = _viewmodel;
    }
}