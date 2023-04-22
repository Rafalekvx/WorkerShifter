
using WorkerShifter.ViewModels.StoresViewModels;

namespace WorkerShifter.Views.Stores;

public partial class StoresPage : ContentPage
{
    protected StoresPageViewModel _viewModel;
	public StoresPage()
	{
		InitializeComponent();
        _viewModel = new StoresPageViewModel();
		this.BindingContext = _viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetStoreList();
    }

}