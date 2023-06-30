using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using WorkerShifter.Views.Shifts;

namespace WorkerShifter.ViewModels.ShiftsViewModels
{
    [QueryProperty(nameof(SelectDate), nameof(SelectDate))]
    public partial class ShiftDetailsPageViewModel : ShiftBaseViewModel
    {
        private ShiftModelDto _selectedWorkerModel;
        public Command<ShiftModelDto> ItemTapped { get; }

        [ObservableProperty]
        private DateTime _selectDate;
        public DateTime selectDate
        {
            get
            {
                return SelectDate;
            }
            set
            {
                SelectDate = value;
            }
        }

        public ObservableCollection<ShiftModelDto> Shifts { get; }

        public ShiftDetailsPageViewModel()
        {
            Shifts = new ObservableCollection<ShiftModelDto>();

            ItemTapped = new Command<ShiftModelDto>(OnItemSelected);
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
                    if (item.date.ToString("yyyy-MM-dd").Equals(selectDate.ToString("yyyy-MM-dd")))
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

                        if (item.endTime.ToString("yyyy-MM-dd").Equals(item.startTime.ToString("yyyy-MM-dd")))
                        {
                            Shifts.Add(new ShiftModelDto()
                            {
                                Id = item.Id,
                                date = item.date.ToString("dd/MM/yyyy"),
                                endTime = item.endTime.ToString("HH:mm"),
                                startTime = item.startTime.ToString("HH:mm"),
                                Store = storeName.name,
                                workerName = workerNameGet.name
                            });
                        }
                        else
                        {
                            Shifts.Add(new ShiftModelDto()
                            {
                                Id = item.Id,
                                date = item.date.ToString("dd/MM/yyyy"),
                                endTime = item.endTime.ToString("dd/MM/yyyy HH:mm"),
                                startTime = item.startTime.ToString("HH:mm"),
                                Store = storeName.name,
                                workerName = workerNameGet.name
                            });

                        }
                    }
                }
            }

        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async void OnItemSelected(ShiftModelDto model)
        {
            if (model == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(ShiftUpdatePage)}?{nameof(ShiftUpdatePageViewModel.ItemId)}={model.Id}");

        }

    }
}
