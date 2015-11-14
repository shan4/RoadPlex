using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace RoadTransportFinal.VehicleReg.Sub_service
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class slot : Page
    {
        static string SLOT_URL = "http://roadtransportdb.azurewebsites.net/vhslot.php";
        static string response = "";
        public slot()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
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
        static async Task AsyncTask(Dictionary<string, string> pairs)
        {
            Uri signup_uri = new Uri(SLOT_URL);
            HttpClient client = new HttpClient();
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ToString();

            }
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
        DateTime result;
        private async void checkB_Click(object sender, RoutedEventArgs e)
        {
            DateTime.TryParse(slotdate.Date.ToString(), out result);
            string dateFormat = result.ToString("yyyy-MM-dd");
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("date", dateFormat);
            await AsyncTask(pairs);

            if (response != "")
            {
                var list = JsonConvert.DeserializeObject<List<Bindings.Slot1>>(response);
                Frame.Navigate(typeof(Slot1), list);
            }
            if (dateFormat == "")
            {
                await new MessageDialog("Please select a date").ShowAsync();
            }
            else
            {

            }
        }
    }
}
