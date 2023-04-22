using WorkerShifter.ViewModels.WorkersViewModels;

namespace WorkerShifter.Views.Workers;

public partial class WorkerUpdatePage : ContentPage
{
    WorkerUpdatePageViewModel _viewmodel;
    public WorkerUpdatePage()
	{
		InitializeComponent();
        _viewmodel = new WorkerUpdatePageViewModel();
        this.BindingContext = _viewmodel;
    }
}