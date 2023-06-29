using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerShifter.Models;
using WorkerShifter.Services;

namespace WorkerShifter.ViewModels.WorkersViewModels
{
    public partial class WorkerCreatePageViewModel : WorkerBaseViewModel
    {
        public ObservableCollection<ComboItem> StoresPicker 
        {
            get;
            set;
        }


        [ObservableProperty]
        private ComboItem _store;

        public ComboItem SelectedStore
        {
            get { return Store; }
            set
            {
                Store = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ComboItem> BossPicker
        {
            get;
            set;
        }


        [ObservableProperty]
        private ComboItem _bossPick;

        public ComboItem SelectedBoss
        {
            get { return BossPick; }
            set
            {
                BossPick = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<ComboItem> PositionPicker
        {
            get;
            set;
        }


        [ObservableProperty]
        private ComboItem _positionPick;

        public ComboItem SelectedPosition
        {
            get { return PositionPick; }
            set
            {
                PositionPick = value;
                OnPropertyChanged();
            }
        }


        public WorkerCreatePageViewModel() 
        {
            StoresPicker = new();
            GetStorePicker();
            BossPicker = new();
            GetBossPicker();
            PositionPicker = new();
            GetPositionPicker();

        }


        public async void GetPositionPicker()
        {

            List<PositionModel> Positions = await _positionManageServices.GetAll();

            if (PositionPicker != null)
            {
                PositionPicker.Clear();
            }

            foreach (PositionModel position in Positions)
            {
                PositionPicker.Add(new ComboItem() { Id = position.Id, Text = position.Position });
            }

        }

        public async void GetStorePicker()
        {

            List<StoreModel> Stores = await _storeManageServices.GetAll();

            if (StoresPicker != null)
            {
                StoresPicker.Clear();
            }

            foreach (StoreModel store in Stores)
            {
                StoresPicker.Add(new ComboItem() { Id = store.id, Text = $"{store.name} , {store.address}" });
            }

        }
        public async void GetBossPicker()
        {

            List<PositionModel> helperPositionWithBoss = await _positionManageServices.GetAll();
            List<int> positionWithBoss = new();
            foreach(PositionModel position in helperPositionWithBoss)
            {
                if(position.IsBoss == true)
                {
                    positionWithBoss.Add(position.Id);
                }
            }

            List<WorkerModel> workers = await _workerManageServices.GetAll();
            List<WorkerModel> bosses = new();
            foreach (WorkerModel worker in workers)
            {
                if (positionWithBoss.Contains(worker.position))
                {
                    bosses.Add(worker);
                }
            }

            if (BossPicker != null)
            {
                BossPicker.Clear();
            }

            foreach (WorkerModel boss in bosses)
            {
                BossPicker.Add(new ComboItem() { Id = boss.id, Text = boss.name });
            }

        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Name)
                && !String.IsNullOrWhiteSpace(Password);
        }

        [RelayCommand]
        private async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async void Save()
        {
            WorkerModel model = new WorkerModel()
            {
                name = Name,
                position = int.Parse(PositionPick.Id.ToString()),
                password = Password,
                bossId = BossPick.Id,
                deafultStore = Store.Id
            };

            await _workerManageServices.Create(model);

            await Shell.Current.GoToAsync("..");
        }
    }
}
