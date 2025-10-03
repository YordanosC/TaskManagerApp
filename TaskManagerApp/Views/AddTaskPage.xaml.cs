using TaskManagerApp.ViewModels;

namespace TaskManagerApp.Views;

public partial class AddTaskPage : ContentPage
{
    private readonly AddTaskViewModel _vm;
    public AddTaskPage(AddTaskViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
        _vm.TaskSaved += OnTaskSaved;
    }

    private async void OnTaskSaved(object? sender, EventArgs e)
    {
        // When viewmodel reports saved, pop back to home
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}