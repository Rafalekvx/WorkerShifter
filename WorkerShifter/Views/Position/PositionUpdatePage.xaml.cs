using WorkerShifter.ViewModels.PositionViewModels;

namespace WorkerShifter.Views.Position;

public partial class PositionUpdatePage : ContentPage
{
    PositionUpdatePageViewModel _viewmodel;
	public PositionUpdatePage()
	{
		InitializeComponent();
        _viewmodel = new PositionUpdatePageViewModel();
        this.BindingContext = _viewmodel;
    }
}