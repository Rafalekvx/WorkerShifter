using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;

namespace WorkerShifter.ViewModels.OverviewViewModels
{
    public partial class OverviewPageViewModel : OverviewBaseViewModel
    {
        public ObservableCollection<ShiftModelDto> Shifts { get; }

        public OverviewPageViewModel()
        {
            Shifts = new ObservableCollection<ShiftModelDto>();
        }


        [RelayCommand]
        public async void GetShifts()
        {
            List<ShiftModel> list = await _shiftManageServices.GetAll();

            if (list?.Count > 0)
            {
                Shifts.Clear();

                foreach (var item in list)
                {
                    WorkerModel workerNameGet = new WorkerModel() { name = "brak" };
                    if (item.personId != 0)
                    {
                        workerNameGet = await _workerManageServices.GetOneById(int.Parse(item.personId.ToString()));
                    }
                    StoreModel storeName = new StoreModel() { name = "Brak", address = "Brak" };
                    if (item.storeId != 0)
                    {
                        StoreModel storeNameCheck = await _storeManageServices.GetOneById(int.Parse(item.storeId.ToString()));

                        if (storeNameCheck != null)
                        {
                            storeName = storeNameCheck;
                        }
                    }

                    string storeFullName = $"{storeName.name} , {storeName.address}";

                    Shifts.Add(new ShiftModelDto()
                    {
                        Id = item.Id,
                        date = item.date.ToString("dd/mm/yyyy"),
                        endTime = item.endTime.ToString("HH:mm"),
                        startTime = item.startTime.ToString("HH:mm"),
                        Store = storeName.name,
                        workerName = workerNameGet.name
                    }); 
                }
            }

        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
