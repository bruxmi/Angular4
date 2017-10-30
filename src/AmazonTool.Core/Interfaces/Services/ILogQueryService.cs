using AmazonTool.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTool.Core.Interfaces.Services
{
    public interface ILogQueryService
    {
        Task<int> GetLogsCountAsync(string searchTerm);
        Task<List<Log>> GetLogsWithPagingAsync(int pageIndex, int pageSize, bool isDescending, string searchTerm);
    }
}
