using WorkerShifter.ViewModels.PositionViewModels;

namespace WorkerShifter.Views.Position;

public partial class PositionDetailPage : ContentPage
{
    PositionDetailPageViewModel _viewmodel;
    public PositionDetailPage()
	{
		InitializeComponent();
        _viewmodel = new PositionDetailPageViewModel();
        this.BindingContext = _viewmodel;
    }
}