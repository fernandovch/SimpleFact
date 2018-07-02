using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POS.BLogic.Utilidades
{
    public class Settings
    {
        private readonly string _sqlConnection;
        private readonly string _sample;

        public Settings()
        {
          /*  var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _sqlConnection = root.GetConnectionString("DataConnection");

            var appSetting = root.GetSection("ApplicationSettings");
            var test = appSetting["Sample"];
            */
        }

        public string SqlDataConnection
        {
            get => _sqlConnection;
        }

        public string Sample
        {
            get => _sample;
        }
    }
}
