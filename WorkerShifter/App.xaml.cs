using WorkerShifter.Services;

namespace WorkerShifter;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfRFxnSXxWc0VmXHldeA==;Mgo+DSMBPh8sVXJ1S0R+X1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jT39XdkdmXH9bdXNdTg==;ORg4AjUWIQA/Gnt2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhSckVhXHpedXFcQmg=;MjQxMjU3NkAzMjMxMmUzMDJlMzBSQ2FCaVF2NU83Rk52ZG5JakxCVzdnSmF3cjRpYVQ0U3prODk5ZVZyRFlFPQ==;MjQxMjU3N0AzMjMxMmUzMDJlMzBMQzdsR2VQU2hkZEEvSUJDTEFmTWlNd1c4S2E1TmdEUm0xWkZ4OEJpZDFZPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Vd0FjW3pbcHFTQGVU;MjQxMjU3OUAzMjMxMmUzMDJlMzBhb3VBMXlOY2FoejJWcFc0eHI2cVNDemtvajczd3AyWGhIeGxSOWdnNGJFPQ==;MjQxMjU4MEAzMjMxMmUzMDJlMzBtd2VjQ3pROUlOZTFlYTVab045VFhVNUtMczI1eVdkSWlFa2pyOUkzeEVFPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhSckVhXHpedXNQRGg=;MjQxMjU4MkAzMjMxMmUzMDJlMzBuUi91VXdnL2FnaVZWSXc1dmQ0RW1GdjRFdThnNE5TcnNpai9nUk9VSmFBPQ==;MjQxMjU4M0AzMjMxMmUzMDJlMzBnRTFGbVd5SzJIUTNXY3JKM0FwdUZ6Z0MwYzIvekpQUDExc3cycnF3cnQ4PQ==;MjQxMjU4NEAzMjMxMmUzMDJlMzBhb3VBMXlOY2FoejJWcFc0eHI2cVNDemtvajczd3AyWGhIeGxSOWdnNGJFPQ==");


		DependencyService.Register<StoreServices>();
        DependencyService.Register<WorkerServices>();
        DependencyService.Register<PositionService>();
		DependencyService.Register<ShiftManageServices>();


        MainPage = new AppShell();
	}
}
