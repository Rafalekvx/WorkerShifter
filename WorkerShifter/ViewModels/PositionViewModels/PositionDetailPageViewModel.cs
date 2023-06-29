using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Views.Position;

namespace WorkerShifter.ViewModels.PositionViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PositionDetailPageViewModel : PositionBaseViewModel
    {
        private int itemId;
        public PositionDetailPageViewModel() { }


        [RelayCommand]
        private async void Update()
        {
            await Shell.Current.GoToAsync($"{nameof(PositionUpdatePage)}?{nameof(PositionUpdatePageViewModel.ItemId)}={ItemId}");
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
