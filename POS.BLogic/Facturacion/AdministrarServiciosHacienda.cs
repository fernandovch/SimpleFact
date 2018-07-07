using Newtonsoft.Json;
using POS.BLogic.Utilidades;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLogic.Facturacion
{
    public class AdministrarServiciosHacienda
    {       
        private ManejoErrores Errores;
        private Token SessionToken;

        public Token ObtenerTokenIdP()
        {
            try
            {
                Settings values = new Settings();
                var request = new RestRequest("/token", Method.POST);
                var client = new RestClient();               
                //  client = new RestClient(idp_uriTest);
                client.BaseUrl =new Uri(values.IdP_Uri);
                // agregar parametros del form
                request.AddParameter("grant_type", "password");
                request.AddParameter("username", values.IdP_Usuaio); 
                request.AddParameter("password", values.IdP_Password); 
                request.AddParameter("client_id", values.IdP_Client_Id);                
                // HTTP Headers
                request.AddHeader("Accept", "application/json"); 
                // execute the request
                IRestResponse response = client.Execute(request);
                SessionToken = JsonConvert.DeserializeObject<Token>(response.Content);            
                return SessionToken;
            }
            catch(Exception _ex)
            {
                Errores = new ManejoErrores();
                Errores.RegistrarErrorLog((int)ModuloSistema.MantenimientoFacturaElectronica, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public string DesconectarTokenIdP()
        {
            try
            {
                Settings values = new Settings();
                var request = new RestRequest("/logout", Method.POST);
                var client = new RestClient();                                   
                client.BaseUrl = new Uri(values.IdP_Uri);
                // agregar parametros del form
                request.AddParameter("client_id", values.IdP_Client_Id);
                request.AddParameter("refresh_token", SessionToken.refresh_token);                
                // HTTP Headers
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", "Bearer " + SessionToken.access_token);
                // execute the request
                IRestResponse response = client.Execute(request);
                var eventResponse = response.Content;
                // var content = response.Content; // raw content as string
                return eventResponse;
            }
            catch (Exception _ex)
            {
                Errores = new ManejoErrores();
                Errores.RegistrarErrorLog((int)ModuloSistema.MantenimientoFacturaElectronica, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public string RefrescarToken()
        {
            try
            {
                Settings values = new Settings();
                var request = new RestRequest("/token", Method.POST);
                var client = new RestClient();
                //  client = new RestClient(idp_uriTest);
                client.BaseUrl = new Uri(values.IdP_Uri);
                // agregar parametros del form
                request.AddParameter("grant_type", "refresh_token");
                request.AddParameter("client_id", values.IdP_Client_Id);
                request.AddParameter("refresh_token", SessionToken.refresh_token);
                
                // HTTP Headers
                request.AddHeader("Accept", "application/json");
                // execute the request
                IRestResponse response = client.Execute(request);
                SessionToken = JsonConvert.DeserializeObject<Token>(response.Content);
                return null;
            }
            catch (Exception _ex)
            {
                Errores = new ManejoErrores();
                Errores.RegistrarErrorLog((int)ModuloSistema.MantenimientoFacturaElectronica, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public string EnviarFacturaApiHacienda(FacturaElectronica _factura)
        {
            try
            {
                Settings values = new Settings();
                var request = new RestRequest("/", Method.POST);
                var client = new RestClient();
                //  client = new RestClient(idp_uriTest);
                client.BaseUrl = new Uri(values.IdP_Uri);
                // agregar parametros del form
                // request.AddParameter("grant_type", "refresh_token");
                // request.AddParameter("client_id", values.IdP_Client_Id);
                // request.AddParameter("refresh_token", SessionToken.refresh_token);

                // HTTP Headers
                request.AddHeader("Authorization ", SessionToken.token_type + " " + SessionToken.access_token);
                // execute the request
                IRestResponse response = client.Execute(request);
                SessionToken = JsonConvert.DeserializeObject<Token>(response.Content);
                return null;
            }
            catch (Exception _ex)
            {
                Errores = new ManejoErrores();
                Errores.RegistrarErrorLog((int)ModuloSistema.MantenimientoFacturaElectronica, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

    }
}
