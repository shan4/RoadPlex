using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Regrenewal1 : Page
    {
        static Dictionary<string, string> details1;
        static string RESPONSE = "";
        static string URL = "http://roadtransportdb.azurewebsites.net/renvehicle.php";
        public Regrenewal1()
        {
            this.InitializeComponent();
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
        private async void regrenewB_Click(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == false)
            {
                await new MessageDialog("Please accept Terms and Conditions").ShowAsync();
            }
            else
            {
                string apply = "";
                string reg = "";
                string fuel = "";
                if (lmv.IsChecked.Value) apply += "LMV , ";
                if (heavy.IsChecked.Value) apply += "Heavy , ";
                if (vhl100.IsChecked.Value) apply += "VHL100CC , ";
                if (vhg100.IsChecked.Value) apply += "VHG100CC";
                if (apply.Length != 0)
                    apply = apply.Substring(0, apply.Length - 2);
                if (nw.IsChecked.Value)
                {
                    reg += "New";
                }
                else if (ex.IsChecked.Value)
                {
                    reg += "Ex-Army";
                }
                else if (imported.IsChecked.Value)
                {
                    reg += "Imported";
                }
                if (pet.IsChecked.Value)
                {
                    fuel += "Petrol";
                }
                else if (die.IsEnabled)
                {
                    fuel += "Diesel";
                }
                else if (any.IsEnabled)
                {
                    fuel += "Others";
                }
                DateTime dateValue = DateTime.Parse(dom.Date.ToString());
                string dateFormat = dateValue.ToString("yyyy-MM-dd");
                //start basic validation
                if (cha.Text == "" || seat.Text == "" || fuel == "" || reg == ""
                    || cap.Text == "" || apply == "" || dateFormat=="")
                {
                    await new MessageDialog("Fields cannot be blank").ShowAsync();

                }
                else
                {
                    details1.Add("cha1", cha.Text);
                    details1.Add("seat1", seat.Text);
                    details1.Add("fuel", fuel);
                    details1.Add("reg", reg);
                    details1.Add("dom", dateFormat);
                    details1.Add("apply", apply);
                    details1.Add("cap", cap.Text);
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

        private void nw_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ex_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void imported_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void any_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void die_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void pet_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
