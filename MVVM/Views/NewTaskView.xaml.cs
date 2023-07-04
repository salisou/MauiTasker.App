using MauiTasker.MVVM.Models;
using MauiTasker.MVVM.ViewModels;

namespace MauiTasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

    private async void btnAddTask_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;
        var selectedCategory = 
            vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();

        if (selectedCategory != null)
        {
            var task = new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id
            };

            vm.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Invalide Selection", "You must select a category", "OK");
        };
    }

    private async void btnAddCategory_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        string category = 
            await DisplayPromptAsync("New Category",
            "Write the category name", 
            maxLength: 50,
            keyboard: Keyboard.Text);

        var r = new Random();

        if(!string.IsNullOrEmpty(category))
        {
            vm.Categories.Add(
                new Category
                {
                    Id = vm.Categories.Max(x => x.Id) + 1,
                    Color = Color.FromRgb(r.Next(0,255), 
                                          r.Next(0,255),
                                          r.Next(255,255)).ToHex(),
                    CategoryName = category
                });
        };
    }
}