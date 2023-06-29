using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerShifter.Models;
using WorkerShifter.Services;

namespace WorkerShifter.ViewModels.WorkersViewModels
{
    public partial class WorkerBaseViewModel : BaseViewModel
    {

        [ObservableProperty]
        private string _name;
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        [ObservableProperty]
        private string _password;
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        [ObservableProperty]
        private int _position;
        public int position
        {
            get { return Position; }
            set { Position = value; }
        }

        [ObservableProperty]
        private string _positionView;
        public string positionView
        {
            get { return PositionView; }
            set { PositionView = value; }
        }

        [ObservableProperty]
        private int? _boss;
        public int? boss
        {
            get { return Boss; }
            set { Boss = value; }
        }

        [ObservableProperty]
        private string _bossView;
        public string bossView
        {
            get { return BossView; }
            set { BossView = value; }
        }

        [ObservableProperty]
        private int? _deafultStore;
        public int? deafultStore
        {
            get { return DeafultStore; }
            set { DeafultStore = value; }
        }

        [ObservableProperty]
        private string _deafultStoreView;
        public string deafultStoreView
        {
            get { return DeafultStoreView; }
            set { DeafultStoreView = value; }
        }

        public int Id { get; set; }

        public WorkerBaseViewModel()
        {
        }

        public IStoreManageServices<StoreModel> _storeManageServices => DependencyService.Get<IStoreManageServices<StoreModel>>();
        public IStoreManageServices<PositionModel> _positionManageServices => DependencyService.Get<IStoreManageServices<PositionModel>>();
        public IStoreManageServices<WorkerModel> _workerManageServices => DependencyService.Get<IStoreManageServices<WorkerModel>>();
    }
}
