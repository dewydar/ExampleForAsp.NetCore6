using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Context
{
    public class AppConfigrations
    {
        public AppConfigrations()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSettion = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSettion.Value;



            //var srcar = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Create.ar.resx");
            //var src = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Create.resx");
            //var temp = Properties
        }
        public string sqlConnectionString { get; set; }
        

    }
}
