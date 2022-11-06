using BankingTDD.Services;
using BankingTDD.ViewModels;
using BankingTDD.Views;

namespace BankingTDD;

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

        // Register the transaction service
        builder.Services.AddSingleton<ITransactionService, FileTransactionService>();

        // Register the view models
        builder.Services.AddSingleton<TransactionsViewModel>();

        // Register our Main page
        builder.Services.AddSingleton<TransactionsPage>();

        return builder.Build();
	}
}
