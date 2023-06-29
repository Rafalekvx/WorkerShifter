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
        private WorkerModelDto _selectedWorkerModel;
        public ObservableCollection<WorkerModelDto> Workers { get; }
        public Command<WorkerModelDto> ItemTapped { get; }

        public WorkerPageViewModel()
        {
            Workers = new ObservableCollection<WorkerModelDto>();

            ItemTapped = new Command<WorkerModelDto>(OnItemSelected);

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
                    WorkerModel boss = new WorkerModel() { name = "brak"};
                    if (item.bossId != 0)
                    {
                        boss = await _workerManageServices.GetOneById(int.Parse(item.bossId.ToString()));
                    }
                    PositionModel positionId = new PositionModel() { Position = "Brak"};
                    if (item.position != 0)
                    {
                        positionId = await _positionManageServices.GetOneById(item.position);
                    }
                    StoreModel storeName = new StoreModel() { name = "Brak", address = "Brak"};
                    if(item.deafultStore != 0)
                    {
                        StoreModel storeNameCheck = await _storeManageServices.GetOneById(int.Parse(item.deafultStore.ToString()));

                        if(storeNameCheck != null) 
                        {
                            storeName = storeNameCheck;
                        }
                    }

                    string storeFullName = $"{storeName.name} , {storeName.address}";
                    
                    Workers.Add(new WorkerModelDto() { id =item.id,
                        name = item.name, password = 
                        item.password, 
                        boss = boss.name, 
                        position=positionId.Position, 
                        deafultStoreName = storeFullName});
                }
            }

        }
        public void OnAppearing()
        {
            IsBusy = true;
            _selectedWorkerModel = null;
        }

        public WorkerModelDto SelectedWorkerModel
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

        async void OnItemSelected(WorkerModelDto model)
        {
            if (model == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(WorkerDetailPage)}?{nameof(WorkerDetailPageViewModel.ItemId)}={model.id}");

        }
    }
}
