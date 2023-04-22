using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;

namespace WorkerShifter.ViewModels.StoresViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class UpdateStorePageViewModel : StoreBaseViewModel
    {

        private int itemId;

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



        public UpdateStorePageViewModel()
        {

        }

        [RelayCommand]
        private async void UpdateStore()
        {
            StoreModel storeModel = new StoreModel()
            {
                id = Id,
                name = Name,
                address = Address
            };

            await _storeManageServices.Update(storeModel);

            await Shell.Current.GoToAsync("../..");
        }

        [RelayCommand]
        private async void CancelUpdateStore()
        {
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private async void DeleteStore()
        {
            await _storeManageServices.Delete(Id);
            await Shell.Current.GoToAsync("../..");
        }


        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await _storeManageServices.GetOneById(itemId);
                Id = item.id;
                Name = item.name;
                Address = item.address;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
