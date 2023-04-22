using WorkerShifter.ViewModels.StoresViewModels;

namespace WorkerShifter.Views;

public partial class NewStorePage : ContentPage
{
	public NewStorePage()
	{
		InitializeComponent();

		this.BindingContext = new NewStorePageViewModel();
	}
}