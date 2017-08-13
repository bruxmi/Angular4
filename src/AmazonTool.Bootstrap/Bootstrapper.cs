using AmazonTool.Business;
using AmazonTool.Core.Interfaces.Services;
using Autofac;
using System;

namespace AmazonTool.Bootstrap
{
    public static class Bootstrapper
    {
        public static ContainerBuilder BootstrapApplication()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProductQueryService>().As<IProductQueryService>();
            return builder;
        }
    }
}
