using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTool.Core.Interfaces.Services
{
    public interface ILog
    {
        void Debug(string message);

        void Error(string message, Exception e);

        void Fatal(string message, Exception e);

        void Info(string message);

        void Warn(string message);
    }
}
