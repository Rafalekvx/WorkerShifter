using WorkerShifter.ViewModels.ShiftsViewModels;

namespace WorkerShifter.Views.Shifts;

public partial class ShiftDetailPage : ContentPage
{
    ShiftDetailPageViewModel _viewmodel;
	public ShiftDetailPage()
	{
		InitializeComponent();
        _viewmodel = new ShiftDetailPageViewModel();
        this.BindingContext = _viewmodel;
    }
}