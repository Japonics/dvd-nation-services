﻿using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace game_nation_api_gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true)
                        .AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true)
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(s => {
                    s.AddOcelot();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    //add your logging
                })
                .UseIISIntegration()
                .Configure(app =>
                {
                    app.UseOcelot().Wait();
                })
                .Build()
                .Run();
        }
    }
}