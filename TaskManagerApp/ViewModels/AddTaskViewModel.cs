using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagerApp.Models;
using TaskManagerApp.Services;

namespace TaskManagerApp.ViewModels
{
    public class AddTaskViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;

        public event EventHandler? TaskSaved;

        private string _title = string.Empty;
        public string Title { get => _title; set { SetProperty(ref _title, value); SaveCommand.ChangeCanExecute(); } }

        private DateTime _dueDate = DateTime.Now;
        public DateTime DueDate { get => _dueDate; set => SetProperty(ref _dueDate, value); }

        private bool _isCompleted = false;
        public bool IsCompleted { get => _isCompleted; set => SetProperty(ref _isCompleted, value); }

        public Command SaveCommand { get; }

        public AddTaskViewModel(ITaskService taskService)
        {
            _taskService = taskService;
            SaveCommand = new Command(async () => await SaveAsync(), CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }

        private async Task SaveAsync()
        {
            var task = new TaskItem
            {
                Title = this.Title,
                DueDate = this.DueDate,
                IsCompleted = this.IsCompleted
            };

            await _taskService.AddTaskAsync(task);

            // raise saved event so page can pop and home can refresh
            TaskSaved?.Invoke(this, EventArgs.Empty);
        }
    }

}
