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

namespace RoadTransportFinal.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class changeofaddress1 : Page
    {
        static Dictionary<string, string> details1;
        static string RESPONSE = "";
        static string URL = "http://roadtransportdb.azurewebsites.net/changeadd.php";
        public changeofaddress1()
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            details1 = e.Parameter as Dictionary<string, string>;
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
        private async void nextr_Click(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == false)
            {
                await new MessageDialog("Please accept Terms and Conditions").ShowAsync();
            }
            else
            {
                //start basic validation
                if (house1.Text == "" || phno1.Text == "" || city1.Text == "" || District1.Text == ""
                    || pincode1.Text == "" || state1.SelectedItem.ToString() == "" || regnum.Text == "")
                {
                    await new MessageDialog("Fields cannot be blank").ShowAsync();

                }
                else
                {
                    details1.Add("house1", house1.Text);
                    details1.Add("phno1", phno1.Text);
                    details1.Add("city1", city1.Text);
                    details1.Add("regnum", regnum.Text);
                    details1.Add("district1", District1.Text);
                    details1.Add("state1", state1.SelectedItem.ToString());
                    details1.Add("pincode1", pincode1.Text);
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    string id = localSettings.Values["id"].ToString();
                    details1.Add("id", id);
                    await AsyncTask(details1);
                }
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

     
    }
}
