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

namespace RoadTransportFinal.DrivingLicense.Sub_Services
{
    /// <summary>
    /// Class Renewal1. The second part of application for Renewal
    /// </summary>
    public sealed partial class Renewal1 : Page
    {
        static Dictionary<string, string> details;
        static string RESPONSE = "";

        /// <summary>
        /// The URL of webservice.
        /// </summary>
        static string URL = "http://roadtransportdb.azurewebsites.net/renlic.php";

        /// <summary>
        /// Initializes a new instance of the <see cref="Renewal1"/> class.
        /// </summary>
        public Renewal1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the <see cref="E:NavigatedTo" /> event. Gets the values from previous page
        /// </summary>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            details = e.Parameter as Dictionary<string, string>;
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

        /// <summary>
        /// Asynchronouses the task. Creates a http post request and parses the response.
        /// </summary>
        /// <param name="pairs">The pairs.</param>
        /// <returns>Task.</returns>
        static async Task AsyncTask(Dictionary<string, string> pairs)
        {
            //setup http client
            Uri signup_uri = new Uri(URL);
            HttpClient client = new HttpClient();
            //put form data
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);

            //get response
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {
                var dialog = new MessageDialog(res.Content.ToString());
                await dialog.ShowAsync();
                //store response in string
                RESPONSE = res.Content.ToString();
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
        /// <summary>
        /// Handles the Click event of the renewB control. Validates, adds and calls the asynctask.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void renewB_Click(object sender, RoutedEventArgs e)
        {
            string apply = "";
            if (lmv.IsChecked.Value) apply += "LMV , ";
            if (heavy.IsChecked.Value) apply += "Heavy , ";
            if (vhl100.IsChecked.Value) apply += "VHL100CC , ";
            if (vhg100.IsChecked.Value) apply += "VHG100CC";
            if (apply.Length != 0)
                apply = apply.Substring(0, apply.Length - 2);
            //start basic validation
            if (house.Text == "" || city.Text == "" || pincode.Text == "" || district.Text == ""
                || state.SelectedItem.ToString() == "" || apply == "")
            {
                await new MessageDialog("Fields cannot be blank").ShowAsync();

            }
            else
            {
                details.Add("hno", house.Text);
                details.Add("district", district.Text);
                details.Add("city", city.Text);
                details.Add("pincode", pincode.Text);
                details.Add("state", state.SelectedItem.ToString());
                details.Add("apply", apply);
                details.Add("mobile", phno.Text);
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string id = localSettings.Values["id"].ToString();
                details.Add("id", id);
                await AsyncTask(details);

            }
        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }
    }
}
