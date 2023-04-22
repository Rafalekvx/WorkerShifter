using WorkerShifter.ViewModels.WorkersViewModels;

namespace WorkerShifter.Views.Workers;

public partial class WorkerPage : ContentPage
{
	WorkerPageViewModel _viewmodel;
	public WorkerPage()
	{
		InitializeComponent();
		_viewmodel = new WorkerPageViewModel();
		this.BindingContext = _viewmodel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewmodel.GetWorkerList();
    }
}