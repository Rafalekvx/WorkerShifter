using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using WorkerShifter.Services;

namespace WorkerShifter.ViewModels.ShiftsViewModels
{
    public partial class ShiftBaseViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _id;
        public string id
        {
            get { return Id; }
            set { Id = value; }
        }
        [ObservableProperty]
        private DateTime _date;
        public DateTime date
        {
            get { return Date; }
            set { Date = value; }
        }

        [ObservableProperty]
        private DateTime _startTime;
        public DateTime startTime
        {
            get { return StartTime; }
            set { StartTime = value; }
        }

        [ObservableProperty]
        private DateTime _endTime;
        public DateTime endTime
        {
            get { return EndTime; }
            set { EndTime = value; }
        }


        [ObservableProperty]
        private int _personId;
        public int personId
        {
            get { return PersonId; }
            set { PersonId = value; }
        }


        [ObservableProperty]
        private int _storeId;
        public int storeId
        {
            get { return StoreId; }
            set { StoreId = value; }
        }


        public IStoreManageServices<ShiftModel> _shiftManageServices => DependencyService.Get<IStoreManageServices<ShiftModel>>();
        public IStoreManageServices<StoreModel> _storeManageServices => DependencyService.Get<IStoreManageServices<StoreModel>>();
        public IStoreManageServices<WorkerModel> _workerManageServices => DependencyService.Get<IStoreManageServices<WorkerModel>>();


    }
}
