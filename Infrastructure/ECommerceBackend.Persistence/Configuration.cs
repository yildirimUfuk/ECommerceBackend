using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence
{
    static class Configuration
    {
        public static string postgreSQLConnection
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceBackend.BackendAPI"));
                configurationManager.AddJsonFile("appsettings.json");
                return new(configurationManager.GetConnectionString("PostgreSQL"));
            }
        }
    }
}
