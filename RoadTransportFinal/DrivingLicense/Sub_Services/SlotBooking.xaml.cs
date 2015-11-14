using Newtonsoft.Json;
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

namespace RoadTransportFinal.DrivingLicense.Sub_Services
{

    /// <summary>
    /// Class SlotBooking. A service for booking driving license slot.
    /// </summary>
    public sealed partial class SlotBooking : Page
    {

        /// <summary>
        /// The slot url of azure webservice.
        /// </summary>
        static string SLOT_URL = "http://roadtransportdb.azurewebsites.net/dlslot.php";
        static string response = "";
        static string flag;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotBooking"/> class.
        /// </summary>
        public SlotBooking()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                flag = e.Parameter as string;
            }catch(Exception em)
            {
                flag = null;
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


        /// <summary>
        /// Asynchronouses the task. Creates a http post request to the azure webservice and parses the response
        /// </summary>
        /// <param name="pairs">The pairs.</param>
        /// <returns>Task.</returns>
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

        /// <summary>
        /// Handles the Click event of the checkB control. Validates, add and calls the async task.
        /// On success, The json response is deserialized and passed to SlotConfirmation Page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void checkB_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateValue = DateTime.Parse(slotdate.Date.ToString());
            string dateFormat = dateValue.ToString("yyyy-MM-dd");
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("date", dateFormat);
            

            await AsyncTask(pairs);
            
            if(response != "")
            {
                
                var list = JsonConvert.DeserializeObject<List<Bindings.Slot>>(response);
                List<Object> mylist = new List<object>();
                mylist.Add(list);
                if (flag != null)
                {
                    mylist.Add(flag);
                }
                Frame.Navigate(typeof(SlotConfirmation), mylist);
            }
            else
            {

            }
        }
    }
}
