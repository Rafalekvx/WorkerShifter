using Microsoft.Extensions.Logging;
using WorkerShifter.Models;
using WorkerShifter.Services;
using WorkerShifter.ViewModels;
using WorkerShifter.ViewModels.StoresViewModels;
using WorkerShifter.ViewModels.WorkersViewModels;
using WorkerShifter.Views;
using WorkerShifter.Views.Shifts;
using WorkerShifter.Views.Stores;
using WorkerShifter.Views.Workers;

namespace WorkerShifter;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif



        //services
        builder.Services.AddSingleton<IStoreManageServices<StoreModel>, StoreServices>();
        builder.Services.AddSingleton<IStoreManageServices<WorkerModel>, WorkerServices>();


        //viewmodels
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<MainPageViewModel>();
        //shifts
        builder.Services.AddTransient<ShiftPageViewModel>();
        //workers
        builder.Services.AddTransient<WorkerPageViewModel>();
        builder.Services.AddTransient<WorkerCreatePageViewModel>();
        builder.Services.AddTransient<WorkerDetailPageViewModel>();
        builder.Services.AddTransient<WorkerUpdatePageViewModel>();
        //stores
        builder.Services.AddTransient<StoresPageViewModel>();
        builder.Services.AddTransient<NewStorePageViewModel>();
        builder.Services.AddTransient<StoreDetailPageViewModel>();
        builder.Services.AddTransient<UpdateStorePageViewModel>();

        //views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ShiftPage>();

        //stores
        builder.Services.AddTransient<StoresPage>();
        builder.Services.AddTransient<NewStorePage>();
        builder.Services.AddTransient<StoreDetailPage>();
        builder.Services.AddTransient<UpdateStorePage>();
        //workers
        builder.Services.AddTransient<WorkerPage>();
        builder.Services.AddTransient<WorkerCreatePage>();
        builder.Services.AddTransient<WorkerDetailPage>();
        builder.Services.AddTransient<WorkerUpdatePage>();
        return builder.Build();
	}
}
