using WorkerShifter.Views;
using WorkerShifter.Views.Stores;
using WorkerShifter.Views.Workers;

namespace WorkerShifter;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();
        
        //store
        Routing.RegisterRoute(nameof(NewStorePage), typeof(NewStorePage));
        Routing.RegisterRoute(nameof(StoreDetailPage), typeof(StoreDetailPage));
        Routing.RegisterRoute(nameof(UpdateStorePage), typeof(UpdateStorePage));

        //workers
        Routing.RegisterRoute(nameof(WorkerCreatePage), typeof(WorkerCreatePage));
        Routing.RegisterRoute(nameof(WorkerDetailPage), typeof(WorkerDetailPage));
        Routing.RegisterRoute(nameof(WorkerUpdatePage), typeof(WorkerUpdatePage));


    }
}
