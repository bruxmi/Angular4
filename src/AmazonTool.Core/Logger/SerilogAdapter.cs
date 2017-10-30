using AmazonTool.Core.Interfaces.Services;
using Serilog;
using System;

namespace AmazonTool.Core.Logger
{
    public class SerilogAdapter: ILog
    {
        private readonly ILogger serlig;

        public SerilogAdapter(ILogger serilog)
        {
            this.serlig = serilog;
        }

        public virtual void Debug(string message)
        {
            this.serlig.Debug(message);
        }

        public virtual void Error(string message, Exception e)
        {
            this.serlig.Error(e, message);
        }

        public virtual void Fatal(string message, Exception e)
        {
            this.serlig.Fatal(e, message);
        }

        public virtual void Info(string message)
        {
            this.serlig.Information(message);
        }

        public virtual void Warn(string message)
        {
            this.serlig.Warning(message);
        }
    }
}
