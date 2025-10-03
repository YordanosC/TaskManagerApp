using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetTasksAsync();
        Task<int> AddTaskAsync(TaskItem task);
        Task<int> UpdateTaskAsync(TaskItem task);
        Task<int> DeleteTaskAsync(TaskItem task);
    }
}
