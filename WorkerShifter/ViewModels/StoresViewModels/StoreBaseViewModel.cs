using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerShifter.Models;
using WorkerShifter.Services;

namespace WorkerShifter.ViewModels.StoresViewModels
{
    public partial class StoreBaseViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _name;
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        [ObservableProperty]
        private string _address;
        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        public int Id { get; set; }

        public IStoreManageServices<StoreModel> _storeManageServices => DependencyService.Get<IStoreManageServices<StoreModel>>();


    }
}
