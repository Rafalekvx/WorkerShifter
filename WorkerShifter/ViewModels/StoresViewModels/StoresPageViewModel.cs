using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using WorkerShifter.Services;
using WorkerShifter.Views;

namespace WorkerShifter.ViewModels.StoresViewModels
{
    public partial class StoresPageViewModel : StoreBaseViewModel
    {



        public StoreModel _selectedStoreModel;

        public StoreModel SelectedStoreModel
        {
            get { return _selectedStoreModel; }
            set
            {
                SetProperty(ref _selectedStoreModel, value);

            }
        }

        public ObservableCollection<StoreModel> Stores { get; }
        public Command<StoreModel> ItemTapped { get; }

        public StoresPageViewModel() 
        {
            Stores = new ObservableCollection<StoreModel>();

            ItemTapped = new Command<StoreModel>(OnItemSelected);

            GetStoreList();
        }


        [RelayCommand]
        public async void GetStoreList()
        {
            List<StoreModel> list = await _storeManageServices.GetAll();

            if(list?.Count > 0)
            {
                Stores.Clear();

                foreach(var item in list)
                {
                    Stores.Add(item);
                }
            }

        }
        public void OnAppearing()
        {
            IsBusy = true;
            _selectedStoreModel = null;
        }


        [RelayCommand]
        public async void AddStore()
        {
            await Shell.Current.GoToAsync(nameof(NewStorePage));
        }

        async void OnItemSelected(StoreModel model)
        {
            if (model == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(StoreDetailPage)}?{nameof(StoreDetailPageViewModel.ItemId)}={model.id}");

        }


    }
}
