using MauiTasker.MVVM.ViewModels;

namespace MauiTasker.MVVM.Views;

public partial class MainView : ContentPage
{
    private MainViewModel _mainViewModel = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
        BindingContext = _mainViewModel;

    }

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView()
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = _mainViewModel.Tasks,
                Categories = _mainViewModel.Categories
            }
        };

        if (taskView != null )
        {
            Navigation.PushAsync(taskView);
        }
        else
        {
            DisplayAlert("Error!", "Loading this page", "Ok");
        }

        
    }
}