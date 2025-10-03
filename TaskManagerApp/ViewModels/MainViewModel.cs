using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagerApp.Models;
using TaskManagerApp.Services;
using TaskManagerApp.Views;

namespace TaskManagerApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;
        private readonly IQuoteService _quoteService;

        public ObservableCollection<TaskItem> Tasks { get; } = new();

        private string _quote = "Press 'Fetch Quote' to load one.";
        public string Quote { get => _quote; set => SetProperty(ref _quote, value); }

        public Command LoadTasksCommand { get; }
        public Command FetchQuoteCommand { get; }

        public MainViewModel()
        {
            
        }
        public MainViewModel(ITaskService taskService, IQuoteService quoteService)
        {
            _taskService = taskService;
            _quoteService = quoteService;

            LoadTasksCommand = new Command(async () => await LoadTasksAsync());
            FetchQuoteCommand = new Command(async () => await FetchQuoteAsync());
        }

        private async Task LoadTasksAsync()
        {
            var items = await _taskService.GetTasksAsync();
            Tasks.Clear();
            foreach (var t in items)
                Tasks.Add(t);
        }

        private async Task FetchQuoteAsync()
        {
            Quote = "Loading...";
            Quote = await _quoteService.GetMotivationalQuoteAsync();
        }

    }
}
