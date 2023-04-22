using WorkerShifter.ViewModels.StoresViewModels;

namespace WorkerShifter.Views;

public partial class StoreDetailPage : ContentPage
{
    StoreDetailPageViewModel _viewModel;

    public StoreDetailPage()
	{
		InitializeComponent();

        _viewModel = new StoreDetailPageViewModel();
        this.BindingContext = _viewModel;
	}

}