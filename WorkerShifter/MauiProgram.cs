using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using WorkerShifter.Models;
using WorkerShifter.Services;
using WorkerShifter.ViewModels;
using WorkerShifter.ViewModels.OverviewViewModels;
using WorkerShifter.ViewModels.PositionViewModels;
using WorkerShifter.ViewModels.ShiftsViewModels;
using WorkerShifter.ViewModels.StoresViewModels;
using WorkerShifter.ViewModels.WorkersViewModels;
using WorkerShifter.Views;
using WorkerShifter.Views.OverviewPage;
using WorkerShifter.Views.Position;
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
            .ConfigureSyncfusionCore()
            .UseMauiCommunityToolkit()
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
        builder.Services.AddSingleton<IStoreManageServices<PositionModel>, PositionService>();
        builder.Services.AddSingleton<IStoreManageServices<ShiftModel>, ShiftManageServices>();

        //viewmodels
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<OverviewPageViewModel>();
        //shifts
        builder.Services.AddTransient<ShiftPageViewModel>();
        builder.Services.AddTransient<ShiftCreatePageViewModel>();
        builder.Services.AddTransient<ShiftDetailsPageViewModel>();
        builder.Services.AddTransient<ShiftUpdatePageViewModel>();
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
        //position
        builder.Services.AddTransient<PositionPageViewModel>();
        builder.Services.AddTransient<PositionCreatePageViewModel>();
        builder.Services.AddTransient<PositionDetailPageViewModel>();
        builder.Services.AddTransient<PositionUpdatePageViewModel>();


        //views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ShiftPage>();
        builder.Services.AddTransient<OverviewPage>();
        //shifts
        builder.Services.AddTransient<ShiftPage>();
        builder.Services.AddTransient<ShiftCreatePage>();
        builder.Services.AddTransient<ShiftDetailsPage>();
        builder.Services.AddTransient<ShiftUpdatePage>();
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
        //position
        builder.Services.AddTransient<PositionPage>();
        builder.Services.AddTransient<PositionCreatePage>();
        builder.Services.AddTransient<PositionDetailPage>();
        builder.Services.AddTransient<PositionUpdatePage>();

      


        return builder.Build();
	}
}
