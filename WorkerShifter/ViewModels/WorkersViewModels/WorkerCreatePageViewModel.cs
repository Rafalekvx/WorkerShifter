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
        public ObservableCollection<ComboItem> StoresPicker { get; set; }

        private IStoreManageServices<StoreModel> _storeManageServices => DependencyService.Get<IStoreManageServices<StoreModel>>();

        public void SelectedDefaultStore()
        {

        }


        public WorkerCreatePageViewModel() 
        {
        }
        public async Task<ObservableCollection<ComboItem>> GetList()
        {
            List<StoreModel> Stores = await _storeManageServices.GetAll();

            ObservableCollection<ComboItem> DeafultStoreItems = new ObservableCollection<ComboItem>();

            foreach (StoreModel store in Stores)
            {
                DeafultStoreItems.Add(new ComboItem() { Id = store.id, Text = $"{store.name} , {store.address}" });
            }

            return DeafultStoreItems;
        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Name)
                && !String.IsNullOrWhiteSpace(Password)
                && !String.IsNullOrWhiteSpace(Position);
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
                position = Position,
                password = Password,
                bossId = Boss,
                deafultStore = DeafultStore
            };

            await _workerManageServices.Create(model);

            await Shell.Current.GoToAsync("..");
        }
    }
}
