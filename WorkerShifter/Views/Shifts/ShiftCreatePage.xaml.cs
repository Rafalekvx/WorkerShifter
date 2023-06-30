using WorkerShifter.ViewModels.ShiftsViewModels;

namespace WorkerShifter.Views.Shifts;

public partial class ShiftCreatePage : ContentPage
{
    ShiftCreatePageViewModel _viewmodel;
	public ShiftCreatePage()
	{
		InitializeComponent();
        _viewmodel = new ShiftCreatePageViewModel();
        this.BindingContext = _viewmodel;
    }
}