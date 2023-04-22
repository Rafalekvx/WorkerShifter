using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WorkerShifter.ViewModels.StoresViewModels
{
    public partial class NewStorePageViewModel : StoreBaseViewModel
    {


        public NewStorePageViewModel()
        {
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Name)
                && !String.IsNullOrWhiteSpace(Address);
        }

        [RelayCommand]
        private async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async void Save()
        {
            StoreModel model = new StoreModel()
            {
                name = Name,
                address = Address
            };
            
            await _storeManageServices.Create(model);

            await Shell.Current.GoToAsync("..");
        }
    }
}
