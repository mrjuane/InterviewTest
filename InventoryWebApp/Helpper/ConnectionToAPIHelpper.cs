using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace InventoryWebApp.Helpper
{
    public class ConnectionToAPIHelpper
    {

        private static HttpClient clientInstance = null;

        private static ConnectionToAPIHelpper Instance = null;

        private static readonly object obj = new object();

        public ConnectionToAPIHelpper()
        {
            clientInstance = new HttpClient();
            clientInstance.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings.Get("APIURL").ToString());
            clientInstance.DefaultRequestHeaders.Clear();
            clientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public HttpClient ClientInstance { get { return clientInstance; } }

        public static ConnectionToAPIHelpper GetInstance
        {
            get
            {
                if (Instance is null)
                {
                    lock (obj)
                    {
                        if (Instance is null)
                        {
                            Instance = new ConnectionToAPIHelpper();
                        }

                    }
                }

                return Instance;
            }
        }

    }
}