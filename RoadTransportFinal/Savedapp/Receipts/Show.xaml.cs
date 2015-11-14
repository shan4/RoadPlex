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

namespace RoadTransportFinal.Savedapp.Receipts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Show : Page
    {
        static string URL = "http://roadtransportdb.azurewebsites.net/payment/details.php";
        static JArray details;
        static bool isthere = true;
        public Show()
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
                dynamic receipts = details;
                foreach (dynamic receipt in receipts)
                {
                    items[i++] = receipt.name.ToString();
                }
                listBox.ItemsSource = items;
            }
        }
        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
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
            dynamic receipts = details;
            foreach (dynamic receipt in receipts)
            {
                if (receipt.name.ToString().Equals(sitem))
                {
                    Frame.Navigate(typeof(ShowEach), receipt);
                }
            }
        }
    }
}

