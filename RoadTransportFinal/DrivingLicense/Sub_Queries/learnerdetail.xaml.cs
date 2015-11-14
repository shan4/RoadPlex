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



namespace RoadTransportFinal.DrivingLicense.Sub_Queries
{

    /// <summary>
    /// Class learnerdetail. A page for learner details
    /// </summary>
    public sealed partial class learnerdetail : Page
    {
        static string URL = "http://roadtransportdb.azurewebsites.net/dldetails.php";
        static JObject details;

        /// <summary>
        /// Initializes a new instance of the <see cref="learnerdetail"/> class.
        /// </summary>
        public learnerdetail()
        {
            this.InitializeComponent();
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
        /// <summary>
        /// Handles the <see cref="E:NavigatedTo" /> event. Calls http request to azure 
        /// </summary>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            myProgressRing.IsActive = true;
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string id = localSettings.Values["id"].ToString();
            Dictionary<string, string> paras = new Dictionary<string, string>();
            paras.Add("id", id);
            await AsyncTask(new CancellationToken(),paras);
            loading.Text = "";
            myProgressRing.IsActive = false;
            if(details != null)
            {
                fullname.Text = "Full Name: " + details.GetValue("fullname").ToString();
                fathername.Text = "Father Name: " + details.GetValue("fathername").ToString();
                appdate.Text = "Applied Date: " + details.GetValue("appdate").ToString();
                appno.Text = "Application No: " + details.GetValue("appno").ToString();
                appfor.Text = "Applied For :" + details.GetValue("appfor").ToString();
                payment.Text = "Payment Status: " + details.GetValue("payment").ToString();
            }
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
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
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
        private void CommandBar_Opened(object sender, object e)
        {

        }
    }
}
