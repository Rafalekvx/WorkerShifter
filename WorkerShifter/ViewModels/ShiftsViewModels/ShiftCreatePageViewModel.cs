using CommunityToolkit.Maui.Views;
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
    public partial class ShiftCreatePageViewModel : ShiftBaseViewModel
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

        public ObservableCollection<ComboItem> WorkerPicker
        {
            get;
            set;
        }


        [ObservableProperty]
        private ComboItem _workerPick;

        public ComboItem SelectedWorker
        {
            get { return WorkerPick; }
            set
            {
                WorkerPick = value;
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        private TimeSpan _startTime;
        
        public TimeSpan startTime
        {
            get { return StartTime; }
            set { StartTime = value; }
        }

        [ObservableProperty]
        private TimeSpan _endTime;

        public TimeSpan endTime
        {
            get { return EndTime; }
            set { EndTime = value; }
        }



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

        public async void GetWorkerPicker()
        {


            List<WorkerModel> workers = await _workerManageServices.GetAll();
            
            if (WorkerPicker != null)
            {
                WorkerPicker.Clear();
            }

            foreach (WorkerModel worker in workers)
            {
                WorkerPicker.Add(new ComboItem() { Id = worker.id, Text = worker.name });
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

        [RelayCommand]
        public void AddShiftButton()
        {
            string startString = selectDate.ToString("yyyy-MM-dd");
            DateTime start = DateTime.ParseExact(startString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + StartTime;
            
            string endString = selectDate.ToString("yyyy-MM-dd");
            DateTime end = DateTime.ParseExact(endString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + EndTime;

            if (EndTime <= StartTime)
            {
                end = end.AddDays(1);
            }


            ShiftModel shiftModel = new ShiftModel() {date = selectDate, 
                startTime = start, 
                endTime = end, 
                personId = SelectedWorker.Id, 
                storeId = SelectedStore.Id };

            _shiftManageServices.Create(shiftModel);
            

            Shell.Current.DisplayAlert(SelectedStore.Text + SelectedWorker.Text, start.ToString() + end.ToString(), "OK");
        }

        [RelayCommand]
        private async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async void GoToDetails()
        {
            string date = selectDate.ToString("MM/dd/yyyy");
            await Shell.Current.GoToAsync($"{nameof(ShiftDetailsPage)}?{nameof(ShiftDetailsPageViewModel.SelectDate)}={date}");
        }

        public ShiftCreatePageViewModel() 
        {
            StoresPicker = new();
            GetStorePicker();
            WorkerPicker = new();
            GetWorkerPicker();
        }
    }
}
