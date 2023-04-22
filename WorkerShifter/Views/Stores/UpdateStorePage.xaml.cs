using WorkerShifter.ViewModels.StoresViewModels;

namespace WorkerShifter.Views.Stores;

public partial class UpdateStorePage : ContentPage
{
	UpdateStorePageViewModel _viewmodel;
	public UpdateStorePage()
	{
		InitializeComponent();
		_viewmodel = new UpdateStorePageViewModel();
		this.BindingContext = _viewmodel;
	}
}