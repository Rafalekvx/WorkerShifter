using WorkerShifter.Views;
using WorkerShifter.Views.OverviewPage;
using WorkerShifter.Views.Position;
using WorkerShifter.Views.Shifts;
using WorkerShifter.Views.Stores;
using WorkerShifter.Views.Workers;

namespace WorkerShifter;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();

        //main
        Routing.RegisterRoute(nameof(OverviewPage), typeof(OverviewPage));

        //store
        Routing.RegisterRoute(nameof(NewStorePage), typeof(NewStorePage));
        Routing.RegisterRoute(nameof(StoreDetailPage), typeof(StoreDetailPage));
        Routing.RegisterRoute(nameof(UpdateStorePage), typeof(UpdateStorePage));

        //workers
        Routing.RegisterRoute(nameof(WorkerCreatePage), typeof(WorkerCreatePage));
        Routing.RegisterRoute(nameof(WorkerDetailPage), typeof(WorkerDetailPage));
        Routing.RegisterRoute(nameof(WorkerUpdatePage), typeof(WorkerUpdatePage));

        //position
        Routing.RegisterRoute(nameof(PositionCreatePage), typeof(PositionCreatePage));
        Routing.RegisterRoute(nameof(PositionDetailPage), typeof(PositionDetailPage));
        Routing.RegisterRoute(nameof(PositionUpdatePage), typeof(PositionUpdatePage));

        //Shifts
        Routing.RegisterRoute(nameof(ShiftPage), typeof(ShiftPage));
        Routing.RegisterRoute(nameof(ShiftCreatePage), typeof(ShiftCreatePage));
        Routing.RegisterRoute(nameof(ShiftDetailsPage), typeof(ShiftDetailsPage));
        Routing.RegisterRoute(nameof(ShiftUpdatePage), typeof(ShiftUpdatePage));
    }
}
