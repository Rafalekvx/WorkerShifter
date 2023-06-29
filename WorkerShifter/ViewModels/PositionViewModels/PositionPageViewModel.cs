using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using WorkerShifter.Services;
using WorkerShifter.Views.Position;

namespace WorkerShifter.ViewModels.PositionViewModels
{
    public partial class PositionPageViewModel : PositionBaseViewModel
    {
        private PositionModel _selectedPositionModel;
        public ObservableCollection<PositionModel> Positions { get; }
        public Command<PositionModel> ItemTapped { get; }

        public PositionPageViewModel() 
        {
            ItemTapped = new Command<PositionModel>(OnItemSelected);

            Positions = new ObservableCollection<PositionModel>();
            GetPositionList();
        }


        [RelayCommand]
        public async void AddPosition()
        {
            await Shell.Current.GoToAsync(nameof(PositionCreatePage));
        }


        [RelayCommand]
        public async void GetPositionList()
        {
            List<PositionModel> list = await _positionManageServices.GetAll();
            if (list?.Count > 0)
            {
                Positions.Clear();
                foreach (var model in list)
                {
                    Positions.Add(model);
                }
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            _selectedPositionModel = null;
        }

        public PositionModel SelectedPositionModel
        {
            get { return _selectedPositionModel; }
            set
            {
                SetProperty(ref _selectedPositionModel, value);
            }
        }
        async void OnItemSelected(PositionModel model)
        {
            if (model == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(PositionDetailPage)}?{nameof(PositionDetailPageViewModel.ItemId)}={model.Id}");

        }

    }
}
