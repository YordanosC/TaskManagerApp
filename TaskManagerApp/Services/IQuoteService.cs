using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Services
{
    public interface IQuoteService
    {
        Task<string> GetMotivationalQuoteAsync();
    }
}
