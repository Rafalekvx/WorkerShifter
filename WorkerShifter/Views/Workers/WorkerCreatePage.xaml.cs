using System.Collections.ObjectModel;
using WorkerShifter.Models;
using WorkerShifter.ViewModels.WorkersViewModels;

namespace WorkerShifter.Views.Workers;

public partial class WorkerCreatePage : ContentPage
{
	WorkerCreatePageViewModel _viewmodel;


    public WorkerCreatePage()
	{
		InitializeComponent();
		_viewmodel = new WorkerCreatePageViewModel();
		this.BindingContext = _viewmodel;
    }

}