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

        public async void StoreViewSet()
        {
            StoreModel storeModelHelper = new();
            try
            {
                storeModelHelper = await _storeManageServices.GetOneById(int.Parse(deafultStore.Value.ToString()));
                deafultStoreView = storeModelHelper.name + " , " + storeModelHelper.address;
            }
            catch (NullReferenceException exNull)
            {
                await Shell.Current.DisplayAlert("Error", "Store assign to this worker not exist, update it!", "OK");

                storeModelHelper = new() { id = 0, address = "Brak", name = "Brak" };
            }

            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Store assign to this worker not exist, update it!", "OK");
            }
        }

        public async void PositionViewSet()
        {
            PositionModel positionModelHelper = new();

            try
            {
                positionModelHelper = await _positionManageServices.GetOneById(position);
                positionView = positionModelHelper.Position;
            }

            catch (NullReferenceException exNull)
            {
                await Shell.Current.DisplayAlert("Error", "Position assign to this worker not exist, update it!", "OK");

                positionModelHelper = new() { Id = 0, IsBoss = false, Position = "Brak" };
            }

            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Position assign to this worker not exist, update it!", "OK");
            }
        }

        public async void BossViewSet()
        {
            WorkerModel workerModelHelper = new();

            try
            {
                workerModelHelper = await _workerManageServices.GetOneById(int.Parse(boss.Value.ToString()));
                bossView = workerModelHelper.name;
            }

            catch (NullReferenceException exNull)
            {
                await Shell.Current.DisplayAlert("Error", "Boss assign to this worker not exist, update it!", "OK");

                workerModelHelper = new() { id = 0, bossId = 0, position = 0, deafultStore = 0, name ="Brak", password="Brak" };
            }

            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Boss assign to this worker not exist, update it!", "OK");
            }
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

                //change to string of name
                Position = item.position;
                Boss = item.bossId;
                DeafultStore = item.deafultStore;
                StoreViewSet();
                PositionViewSet();
                BossViewSet();

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
