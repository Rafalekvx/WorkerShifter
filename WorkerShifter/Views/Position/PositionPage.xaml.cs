using WorkerShifter.ViewModels.PositionViewModels;

namespace WorkerShifter.Views.Position;

public partial class PositionPage : ContentPage
{
	PositionPageViewModel _viewmodel;
	public PositionPage()
	{
		InitializeComponent();
		_viewmodel = new PositionPageViewModel();
		this.BindingContext = _viewmodel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewmodel.GetPositionList();
    }
}