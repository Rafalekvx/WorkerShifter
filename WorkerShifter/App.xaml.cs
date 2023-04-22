using WorkerShifter.Services;

namespace WorkerShifter;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		DependencyService.Register<StoreServices>();
        DependencyService.Register<WorkerServices>();


        MainPage = new AppShell();
	}
}
