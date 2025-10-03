using TaskManagerApp.Views;
namespace TaskManagerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation
            Routing.RegisterRoute(nameof(AddTaskPage), typeof(AddTaskPage));
        }
    }
}
