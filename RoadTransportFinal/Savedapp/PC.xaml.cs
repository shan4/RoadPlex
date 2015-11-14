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

namespace RoadTransportFinal.Savedapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PC : Page
    {
        public PC()
        {
            this.InitializeComponent();
        }
        static string URL = "http://roadtransportdb.azurewebsites.net/pc/pcdetails.php";
        static string URL2 = "http://roadtransportdb.azurewebsites.net/pc/updatepayment.php";
        static string id;
        static JObject details;
        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }

        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }

        private void TextBlock_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
        }

        private void TextBlock_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }

        private void TextBlock_Tapped_4(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            id = localSettings.Values["id"].ToString();
            Dictionary<string, string> paras = new Dictionary<string, string>();
            paras.Add("id", id);
            await AsyncTask(new CancellationToken(), paras);

            if (details != null)
            {
                appno.Text = details.GetValue("pcno").ToString();
                appname.Text = details.GetValue("vhno").ToString();
                pay.Text = details.GetValue("payment").ToString();
                if (details.GetValue("payment").ToString().Equals("PAID"))
                {
                    button1.IsEnabled = false;
                }
            }
        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
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
        }
        static async Task AsyncTask(CancellationToken cts, Dictionary<string, string> pairs)
        {
            Uri signup_uri = new Uri(URL);
            HttpClient client = new HttpClient();
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {

                if (res.Content.ToString().Equals("No details found."))
                {
                    await new MessageDialog("No details found.").ShowAsync();
                }
                else
                {
                    details = JObject.Parse(res.Content.ToString());
                }
            }
        }
        static async Task UpdatePayment(CancellationToken cts, Dictionary<string, string> pairs)
        {
            Uri signup_uri = new Uri(URL2);
            HttpClient client = new HttpClient();
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (!res.IsSuccessStatusCode)
            {
                await new MessageDialog("Server error! Try again later").ShowAsync();
            }
            else
            {
                await new MessageDialog("Moving on").ShowAsync();
            }
        }
        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }
        private void CommandBar_Opened(object sender, object e)
        {

        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            if (details != null)
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("id", id);
                await UpdatePayment(new CancellationToken(), pairs);
                Frame.Navigate(typeof(Payement.payement));

            }


        }
    }
}

