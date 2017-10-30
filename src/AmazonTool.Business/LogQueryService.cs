using AmazonTool.Core.Entities.Application;
using AmazonTool.Core.Interfaces.Repository;
using AmazonTool.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonTool.Business
{
    public class LogQueryService: ILogQueryService
    {
        private readonly IQueryRepository<Log> logQueryRepository;

        public LogQueryService(IQueryRepository<Log> logQueryRepository)
        {
            this.logQueryRepository = logQueryRepository;
        }

        public async Task<int> GetLogsCountAsync(string searchTerm)
        {
            if (searchTerm == "All")
            {
                return await this.logQueryRepository.CountAsync();
            }
            return await this.logQueryRepository.CountAsync(s => s.Level == searchTerm);
        }

        public async Task<List<Log>> GetLogsWithPagingAsync(int pageIndex, int pageSize, bool isDescending, string searchTerm)
        {
            if (searchTerm == "All")
            {
                return await this.logQueryRepository.GetAllWithPagingAsync(l => l.Id, pageIndex, pageSize);
            }
            return await this.logQueryRepository.GetFilteredtWithPagingAndOrderAsync(l => l.Level == searchTerm, l => l.Id, pageIndex, pageSize);
        }
    }
}
