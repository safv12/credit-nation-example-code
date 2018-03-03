namespace LoanService.Api.Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Main program of the application
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Program arguments</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Web host builder method
        /// </summary>
        /// <param name="args">method arguments</param>
        /// <returns><see cref="IWebHost"/> implementation</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
