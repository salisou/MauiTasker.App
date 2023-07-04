using MauiTasker.MVVM.Views;

namespace MauiTasker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainView());
	}
}
