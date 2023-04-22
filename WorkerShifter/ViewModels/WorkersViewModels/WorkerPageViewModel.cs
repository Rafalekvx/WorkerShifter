using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using WorkerShifter.Services;
using WorkerShifter.ViewModels.WorkersViewModels;
using WorkerShifter.Views.Workers;

namespace WorkerShifter.ViewModels.WorkersViewModels
{
    public partial class WorkerPageViewModel : WorkerBaseViewModel
    {
        private WorkerModel _selectedWorkerModel;
        public ObservableCollection<WorkerModel> Workers { get; }
        public Command<WorkerModel> ItemTapped { get; }

        public WorkerPageViewModel()
        {
            Workers = new ObservableCollection<WorkerModel>();

            ItemTapped = new Command<WorkerModel>(OnItemSelected);

            GetWorkerList();
        }


        [RelayCommand]
        public async void GetWorkerList()
        {
            List<WorkerModel> list = await _workerManageServices.GetAll();

            if (list?.Count > 0)
            {
                Workers.Clear();

                foreach (var item in list)
                {
                    Workers.Add(item);
                }
            }

        }
        public void OnAppearing()
        {
            IsBusy = true;
            _selectedWorkerModel = null;
        }

        public WorkerModel SelectedWorkerModel
        {
            get { return _selectedWorkerModel; }
            set
            {
                SetProperty(ref _selectedWorkerModel, value);

            }
        }

        [RelayCommand]
        public async void AddWorker()
        {
            await Shell.Current.GoToAsync(nameof(WorkerCreatePage));
        }

        async void OnItemSelected(WorkerModel model)
        {
            if (model == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(WorkerDetailPage)}?{nameof(WorkerDetailPageViewModel.ItemId)}={model.id}");

        }
    }
}
