using AmazonTool.Core.Constants;
using Serilog.Core;
using Serilog.Events;

namespace AmazonTool.Core.Logger
{
    public class RequestIdEnricher : ILogEventEnricher
    {
        public const string RequestIdProperty = LogConfigurationNames.REQUEST_ID_PARAMETER;
        private LogEventProperty cachedRequestId;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {

            this.cachedRequestId = propertyFactory.CreateProperty(RequestIdProperty, this.GetRequestId());
            logEvent.AddOrUpdateProperty(cachedRequestId);
        }

        private string GetRequestId()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
