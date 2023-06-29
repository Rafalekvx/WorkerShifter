using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerShifter.Models;

namespace WorkerShifter.ViewModels.PositionViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PositionUpdatePageViewModel : PositionBaseViewModel
    {


        public PositionUpdatePageViewModel() { }




        [RelayCommand]
        private async void UpdatePosition()
        {
            PositionModel positionModel = new PositionModel()
            {
                Id = Id,
                Position = Position,
                IsBoss = IsBoss
            };

            await _positionManageServices.Update(positionModel);

            await Shell.Current.GoToAsync("../..");
        }


        [RelayCommand]
        private async void CancelUpdatePosition()
        {
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private async void DeletePosition()
        {
            await _positionManageServices.Delete(Id);
            await Shell.Current.GoToAsync("../..");
        }


        private int itemId;
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
                var item = await _positionManageServices.GetOneById(itemId);
                Id = item.Id;
                Position = item.Position;
                IsBoss = item.IsBoss;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
