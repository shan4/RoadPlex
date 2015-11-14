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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.DrivingLicense.Sub_Services
{

    /// <summary>
    /// Class LearnersRegistration1. A page containting part 2 of the learner registration application.
    /// </summary>
    public sealed partial class LearnersRegistration1 : Page
    {
        static Dictionary<string, string> details;
        static string RESPONSE = "";

        /// <summary>
        /// The Azure Web App URL
        /// </summary>
        static string URL = "http://roadtransportdb.azurewebsites.net/dlreg.php";

        /// <summary>
        /// Initializes a new instance of the <see cref="LearnersRegistration1"/> class.
        /// </summary>
        public LearnersRegistration1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the <see cref="E:NavigatedTo" /> event and gets the values from previous page.
        /// </summary>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            details = e.Parameter as Dictionary<string, string>;
        }

        /// <summary>
        /// Handles the Main Menu event of the AppBarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }

        /// <summary>
        /// Handles the Back event of the AppBarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        /// <summary>
        /// Handles the Settings event of the AppBarButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
        }

        /// <summary>
        /// Handles the Contact event of the AppBarButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }
        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
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
        /// Handles the Personal event of the AppBarButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }

        /// <summary>
        /// Handles the logout event of the AppBarButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }

        /// <summary>
        /// Commands the bar_ opened.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void CommandBar_Opened(object sender, object e)
        {

        }

        /// <summary>
        /// Asynchronouses the task. Creates a http post request from all the values and submits the data to the rest api
        /// the response is then parsed and proper message is shown to the user.
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
               
                //store response in string
                RESPONSE = res.Content.ToString();
            }

        }

        /// <summary>
        /// Handles the Click event of the registerB control. Validates, adds all the details. Calls the asynctask to perform post request
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void registerB_Click(object sender, RoutedEventArgs e)
        {
            string apply = "";
            if (lmv.IsChecked.Value) apply += "LMV , ";
            if (heavy.IsChecked.Value) apply += "Heavy , ";
            if (vhl100.IsChecked.Value) apply += "VHL100CC , ";
            if (vhg100.IsChecked.Value) apply += "VHG100CC";
            DateTime now = DateTime.Now;
            string applydate = now.ToString("yyyy-MM-dd");
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
                details.Add("applydate", applydate);
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string id = localSettings.Values["id"].ToString();
                details.Add("id", id);
                await AsyncTask(details);
                if(RESPONSE.Equals("Registered successfully."))
                {
                    Frame.Navigate(typeof(Next), "Learners");
                }
                else
                {
                    await new MessageDialog(RESPONSE).ShowAsync();
                }
            }
        }
    }
}
