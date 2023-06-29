using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using WorkerShifter.Services;

namespace WorkerShifter.ViewModels.PositionViewModels
{
    public partial class PositionBaseViewModel : BaseViewModel
    {
        public IStoreManageServices<PositionModel> _positionManageServices => DependencyService.Get<IStoreManageServices<PositionModel>>();


        public PositionBaseViewModel() { }


        [ObservableProperty]
        private int _id;

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        [ObservableProperty]
        private string _position;
        public string position
        {
            get { return Position; }
            set { Position = value; }
        }

        [ObservableProperty]
        private bool _isBoss;
        public bool isBoss
        {
            get { return IsBoss; }
            set { IsBoss = value; }
        }

    }
}
