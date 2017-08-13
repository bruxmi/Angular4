using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestAngular2.Middleware
{
    public static class AngularProxyMiddleware
    {
        public static void UseAngular2Routes(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
        }

        public static void UseProxy(this IApplicationBuilder app, string proxyUrl)
        {
            var split = proxyUrl.Split(':');

            var schema = split?[0];
            var host = proxyUrl.Replace("http://", string.Empty).Replace("www.", string.Empty).Split(':')?[0];
            var port = split != null && split.Length > 2 ? split[2] : string.Empty;

            app.RunProxy(new ProxyOptions
            {
                Scheme = schema,
                Host = host,
                Port = port
            });
        }
    }
}
