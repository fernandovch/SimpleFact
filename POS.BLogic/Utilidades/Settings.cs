using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POS.BLogic.Utilidades
{
    public class Settings
    {
        private IConfigurationRoot _root;
        
        public Settings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            _root = configurationBuilder.Build();
        }

        public string IdP_Uri
        {
            get
            {
                return _root.GetSection("TokenService:idp_uri").Value;
            }                      
        }

        public string IdP_Client_Id
        {
            get
            {
                return _root.GetSection("TokenService:idp_client_id").Value;
            }
        }

        public string IdP_Usuaio
        {
            get
            {
                return _root.GetSection("TokenService:idp_usuario").Value;
            }
        }
       
        public string IdP_Password
        {
            get
            {
                return _root.GetSection("TokenService:idp_password").Value;
            }
        }
    }
}
