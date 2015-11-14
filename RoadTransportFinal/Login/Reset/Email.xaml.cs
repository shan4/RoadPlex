using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.Login.Reset
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Email : Page
    {
        static string URL = "http://roadtransportdb.azurewebsites.net/resetpassword.php";
        public Email()
        {
            this.InitializeComponent();
        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Startup));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(Menu.Settings));
            

        }




        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
            //settng.IsEnabled = true;
        }

        private void CommandBar_Opened(object sender, object e)
        {

        }
        static async Task AsyncTask(CancellationToken cts, Dictionary<string, string> pairs)
        {
            Uri signup_uri = new Uri(URL);
            HttpClient client = new HttpClient();
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {

                if (res.Content.ToString().Equals("No account exists."))
                {
                   await new MessageDialog("Sorry! Your email doesnt match with our details!").ShowAsync();
                }
                else if (res.Content.ToString().Equals("Failed."))
                {
                    await new MessageDialog("Server Error! Try after sometime.").ShowAsync();
                }
                else
                {
                    await new MessageDialog("Reset password successful. Please check your email").ShowAsync();
                    
                }
            }
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
           
            string emailid = email.Text;
            if (email.Text == "")
                new MessageDialog("Fields Cannot be blank");
            else
            {
                button.IsEnabled = false;
                Dictionary<string, string> vals = new Dictionary<string, string>();
                vals.Add("email", emailid);
                await AsyncTask(new CancellationToken(), vals);
                button.IsEnabled = true;
            }
                
        }
    }
}
