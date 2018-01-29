using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AppFileUpload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
              .UseHttpSys(options =>
              {
                  
                  options.Authentication.AllowAnonymous = true;
                  options.MaxConnections = 100;
                  options.MaxRequestBodySize = 30000000;
                  //options.UrlPrefixes.Add("http://localhost:5000");
              })
                .UseKestrel(options =>
                {
                    options.Limits.MaxRequestBodySize = null;

                })
                .Build();
    }
}
