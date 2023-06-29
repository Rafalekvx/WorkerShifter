using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerShifter.Models;

namespace WorkerShifter.ViewModels.WorkersViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class WorkerUpdatePageViewModel : WorkerBaseViewModel
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

        private int itemId;

        public WorkerUpdatePageViewModel() 
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
            foreach (PositionModel position in helperPositionWithBoss)
            {
                if (position.IsBoss == true)
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



        [RelayCommand]
        private async void UpdateWorker()
        {
            WorkerModel workerModel = new WorkerModel()
            {
                id = Id,
                name = Name,
                position = PositionPick.Id,
                password = Password,
                bossId = BossPick.Id,
                deafultStore = Store.Id
            };

            await _workerManageServices.Update(workerModel);

            await Shell.Current.GoToAsync("../..");
        }

        [RelayCommand]
        private async void CancelUpdateWorker()
        {
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private async void DeleteWorker()
        {
            await _workerManageServices.Delete(Id);
            await Shell.Current.GoToAsync("../..");
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await _workerManageServices.GetOneById(itemId);
                Id = item.id;
                Name = item.name;
                Password = item.password;
                Position = item.position;

                //change to string of name
                Boss = item.bossId;
                DeafultStore = item.deafultStore;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
