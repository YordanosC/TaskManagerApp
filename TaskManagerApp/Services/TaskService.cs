using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly SQLiteAsyncConnection _db;

        public TaskService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<TaskItem>().Wait();
        }

        public Task<List<TaskItem>> GetTasksAsync()
        {
            return _db.Table<TaskItem>().OrderBy(t => t.DueDate).ToListAsync();
        }

        public Task<int> AddTaskAsync(TaskItem task)
        {
            return _db.InsertAsync(task);
        }

        public Task<int> UpdateTaskAsync(TaskItem task)
        {
            return _db.UpdateAsync(task);
        }

        public Task<int> DeleteTaskAsync(TaskItem task)
        {
            return _db.DeleteAsync(task);
        }
    }
}
