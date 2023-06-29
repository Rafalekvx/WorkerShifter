using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerShifter.ViewModels.ShiftsViewModels
{
    [QueryProperty(nameof(SelectDate), nameof(SelectDate))]
    public partial class ShiftDetailPageViewModel : ShiftBaseViewModel
    {
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

        [RelayCommand]
        public void AddShiftButton()
        {
            
        }

        public ShiftDetailPageViewModel() { }
    }
}
