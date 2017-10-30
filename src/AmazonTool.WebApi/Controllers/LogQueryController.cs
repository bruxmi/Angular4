using AmazonTool.Core.Entities.Application;
using AmazonTool.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular2.Api
{
    [Route("api/[controller]")]
    public class LogQueryController : Controller
    {
        private readonly ILogQueryService logQueryService;

        public LogQueryController(ILogQueryService logQueryService)
        {
            this.logQueryService = logQueryService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]LogPagingGetVm vm)
        {
            var count = await this.logQueryService.GetLogsCountAsync(vm.SearchTerm);
            var logs = await this.logQueryService.GetLogsWithPagingAsync(vm.PageIndex, vm.PageSize, vm.IsDescending, vm.SearchTerm);
            var logMappingService = new LogMappingService();
            vm.Logs = await logMappingService.EntityToGetVmAsync(logs);
            vm.Count = count;
            return Ok(vm);
        }

        public class LogPagingGetVm
        {
            public LogPagingGetVm()
            {
                this.Logs = new List<LogGetVm>();
            }
            public int Count { get; set; }
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public string SearchTerm { get; set; }
            public bool IsDescending { get; set; }
            public List<LogGetVm> Logs { get; set; }
        }

        public class LogGetVm
        {
            public int Id { get; set; }

            public string Message { get; set; }

            public DateTimeOffset TimeStamp { get; set; }

            public string Exception { get; set; }

            public string Level { get; set; }

            public string RequestId { get; set; }

            public string UserName { get; set; }
        }

        public class LogMappingService 
        {
            public async Task<LogGetVm> EntityToGetVmAsync(Log entity)
            {
                return await Task.FromResult(
                    new LogGetVm
                    {
                        Exception = entity.Exception,
                        Level = entity.Level,
                        Id = entity.Id,
                        Message = entity.Message,
                        RequestId = entity.RequestId,
                        TimeStamp = entity.TimeStamp,
                        UserName = entity.UserName
                    });
            }

            public async Task<List<LogGetVm>> EntityToGetVmAsync(List<Log> entities)
            {
                var result = new List<LogGetVm>();
                foreach (var entity in entities)
                {
                    result.Add(await this.EntityToGetVmAsync(entity));
                }
                return result;
            }
        }
    }
}
