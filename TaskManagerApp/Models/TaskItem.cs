using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Models
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
