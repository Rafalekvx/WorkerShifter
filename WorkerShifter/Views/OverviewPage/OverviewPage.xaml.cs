using WorkerShifter.ViewModels.OverviewViewModels;

namespace WorkerShifter.Views.OverviewPage;

public partial class OverviewPage : ContentPage
{
	OverviewPageViewModel _viewmodel;

	public OverviewPage()
	{
		InitializeComponent();
        _viewmodel = new OverviewPageViewModel();
        this.BindingContext = _viewmodel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewmodel.GetShifts();
    }
}