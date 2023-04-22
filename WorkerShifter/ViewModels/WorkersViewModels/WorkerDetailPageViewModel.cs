using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerShifter.Views.Workers;

namespace WorkerShifter.ViewModels.WorkersViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class WorkerDetailPageViewModel : WorkerBaseViewModel
    {
        private int itemId;
        
        public WorkerDetailPageViewModel()
        {

        }

        [RelayCommand]
        private async void Update()
        {
            await Shell.Current.GoToAsync($"{nameof(WorkerUpdatePage)}?{nameof(WorkerUpdatePageViewModel.ItemId)}={ItemId}");
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
