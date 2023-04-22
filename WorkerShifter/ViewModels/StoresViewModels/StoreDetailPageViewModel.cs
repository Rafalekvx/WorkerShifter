using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Views.Stores;

namespace WorkerShifter.ViewModels.StoresViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class StoreDetailPageViewModel : StoreBaseViewModel
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


        public StoreDetailPageViewModel()
        {

        }

        [RelayCommand]
        private async void Update()
        {
            await Shell.Current.GoToAsync($"{nameof(UpdateStorePage)}?{nameof(UpdateStorePageViewModel.ItemId)}={ItemId}");
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
