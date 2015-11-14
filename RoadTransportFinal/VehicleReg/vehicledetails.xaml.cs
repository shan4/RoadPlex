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

namespace RoadTransportFinal.VehicleReg
{
    
    public sealed partial class vehicledetails : Page
    {
        static string URL = "http://roadtransportdb.azurewebsites.net/vehicledetails.php";
        static JArray details;
        static bool isthere = true;
        public vehicledetails()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            isthere = true;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            myProgressRing.IsActive = true;
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string id = localSettings.Values["id"].ToString();
            Dictionary<string, string> paras = new Dictionary<string, string>();
            paras.Add("id", id);
            await AsyncTask(new CancellationToken(), paras);
            if (!isthere) listBox.Visibility = Visibility.Collapsed;
            myProgressRing.IsActive = false;
            if (details != null)
            {
                string[] items = new string[details.Count];
                int i = 0;
                dynamic vehicles = details;
                foreach(dynamic vehicle in vehicles)
                {
                    items[i++] = vehicle.dealer.ToString();
                }
                listBox.ItemsSource = items;
            }
        }
        static async Task AsyncTask(CancellationToken cts, Dictionary<string, string> pairs)
        {
            Uri signup_uri = new Uri(URL);
            HttpClient client = new HttpClient();
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {

                if (res.Content.ToString().Equals("]"))
                {
                    await new MessageDialog("No details found.").ShowAsync();
                    isthere = false;
                }
                else
                {
                    details = JArray.Parse(res.Content.ToString());
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
        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
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

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }
        private void listBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            string sitem = listBox.SelectedItem.ToString();
            dynamic vehicles = details;
            foreach (dynamic vehicle in vehicles)
            {
                if (vehicle.dealer.ToString().Equals(sitem))
                {
                    Frame.Navigate(typeof(vehicledetails2), vehicle);
                }
            }
        }
    }
}
