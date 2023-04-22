using WorkerShifter.ViewModels.WorkersViewModels;

namespace WorkerShifter.Views.Workers;

public partial class WorkerDetailPage : ContentPage
{
	WorkerDetailPageViewModel _viewmodel;
	public WorkerDetailPage()
	{
		InitializeComponent();
		_viewmodel = new WorkerDetailPageViewModel();
		this.BindingContext = _viewmodel;
	}
}