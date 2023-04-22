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
using WorkerShifter.Models;

namespace WorkerShifter.ViewModels.WorkersViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class WorkerUpdatePageViewModel : WorkerBaseViewModel
    {
        private int itemId;

        public WorkerUpdatePageViewModel() 
        {

        }


        [RelayCommand]
        private async void UpdateWorker()
        {
            WorkerModel workerModel = new WorkerModel()
            {
                id = Id,
                name = Name,
                position = Position,
                password = Password,
                bossId = Boss,
                deafultStore = DeafultStore
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
