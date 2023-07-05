using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.ViewModels.ShiftsViewModels;
using WorkerShifter.Views.Shifts;

namespace WorkerShifter.ViewModels.ShiftsViewModels
{
    public partial class ShiftPageViewModel : ShiftBaseViewModel
    {
        [ObservableProperty]
        private DateTime _selectedDate;

        public DateTime selectedDate
        {
            get { return SelectedDate; }
            set { SelectedDate = value; }
        }


        [RelayCommand]
        public async void OnItemSelected(DateTime dateTime)
        {
            string date = dateTime.ToString("dd/MM/yyyy");

            await Shell.Current.GoToAsync($"{nameof(ShiftCreatePage)}?{nameof(ShiftCreatePageViewModel.SelectDate)}={date}");

        }

    }
}
