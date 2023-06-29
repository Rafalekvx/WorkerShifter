using WorkerShifter.ViewModels.PositionViewModels;

namespace WorkerShifter.Views.Position;

public partial class PositionCreatePage : ContentPage
{
    PositionCreatePageViewModel _viewmodel;
    public PositionCreatePage()
	{
		InitializeComponent();
        _viewmodel = new PositionCreatePageViewModel();
        this.BindingContext = _viewmodel;
    }
}