using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerShifter.Models;

namespace WorkerShifter.ViewModels.PositionViewModels
{
    public partial class PositionCreatePageViewModel : PositionBaseViewModel
    {
        public PositionCreatePageViewModel() { }



        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Position);
        }

        [RelayCommand]
        private async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async void Save()
        {
            PositionModel model = new PositionModel()
            {
                Id = Id,
                Position = Position,
                IsBoss = IsBoss
            };

            await _positionManageServices.Create(model);

            await Shell.Current.GoToAsync("..");
        }
    }
}
