using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.UI.Popups;
using System.Threading.Tasks;


namespace RoadTransportFinal.Bindings
{
    class HttpPostRequest
    {
        public string response {
            get; set; }
        public static string NETWORK_ERROR = "Network Connection Failed.";
        public async Task PostAsync(string URL, Dictionary<string, string> data)
        {
            //setup http client
            Uri signup_uri = new Uri(URL);
            HttpClient client = new HttpClient();
            //put form data
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(data);

            //get response
            try
            {
                HttpResponseMessage res = await client.PostAsync(signup_uri, content);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ToString();
                }
            }catch(Exception e)
            {
                response = "NETWORK_ERROR";
            }
           

        }
    }
}
