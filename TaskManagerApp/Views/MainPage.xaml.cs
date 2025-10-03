
using TaskManagerApp.ViewModels;
using static TaskManagerApp.MauiProgram;

namespace TaskManagerApp.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;
    public MainPage( MainViewModel viewModel)
	{
		InitializeComponent();
        // Initialize switch based on current theme
        ThemeSwitch.IsToggled = Application.Current.RequestedTheme == AppTheme.Dark;
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //await _viewModel.LoadTasks();
        if (_viewModel.LoadTasksCommand.CanExecute(null))
            _viewModel.LoadTasksCommand.Execute(null);
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        var svc = ServiceProviderHolder.ServiceProvider;
        if (svc != null)
        {
            var page = svc.GetService<AddTaskPage>();
            if (page != null)
            {
                await Navigation.PushAsync(page);
                return;
            }
        }

        await Navigation.PushAsync(new AddTaskPage(new AddTaskViewModel(ServiceProviderHolder.ServiceProvider.GetService<TaskManagerApp.Services.ITaskService>())));

    }

    private void ThemeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            // Dark Mode
            Application.Current.UserAppTheme = AppTheme.Dark;
        }
        else
        {
            // Light Mode
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }

}


