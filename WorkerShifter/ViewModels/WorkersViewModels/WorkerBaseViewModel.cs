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
        private string _position;
        public string position
        {
            get { return Position; }
            set { Position = value; }
        }

        [ObservableProperty]
        private int? _boss;
        public int? boss
        {
            get { return Boss; }
            set { Boss = value; }
        }

        [ObservableProperty]
        private int? _deafultStore;
        public int? deafultStore
        {
            get { return DeafultStore; }
            set { DeafultStore = value; }
        }

        public int Id { get; set; }

        public WorkerBaseViewModel()
        {

        }

     
        public IStoreManageServices<WorkerModel> _workerManageServices => DependencyService.Get<IStoreManageServices<WorkerModel>>();
    }
}
