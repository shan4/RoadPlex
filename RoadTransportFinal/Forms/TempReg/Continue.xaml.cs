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
using Windows.Web.Http;
using System.Threading.Tasks;
using RoadTransportFinal.DrivingLicense.Sub_Services;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.Forms.TempReg
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Continue : Page
    {
        static Boolean flag = false;
        static Dictionary<string, string> details1;
        static string RESPONSE = "";
        static string URL = "http://roadtransportdb.azurewebsites.net/vehiclereg.php";
        public Continue()
        {
            this.InitializeComponent();
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
                
                //store response in string
                RESPONSE = res.Content.ToString();
                flag = false;
            }

        }
        DateTime result;
        private async void regrenewB_Click(object sender, RoutedEventArgs e)
        {
           
            if (check.IsChecked == false)
            {
                await new MessageDialog("Please accept Terms and Conditions").ShowAsync();
            }
            else
            {
                DateTime now = DateTime.Now;
                string applydate = now.ToString("yyyy-MM-dd");
                string apply = "";
                string fuel = "";
                if (lmv.IsChecked.Value) apply += "LMV , ";
                if (heavy.IsChecked.Value) apply += "Heavy , ";
                if (vhl100.IsChecked.Value) apply += "VHL100CC , ";
                if (vhg100.IsChecked.Value) apply += "VHG100CC";
                if(apply.Length!=0)
                apply = apply.Substring(0, apply.Length - 2);
                if (pet.IsChecked.Value)
                {
                    fuel += "Petrol";
                }
                else if (die.IsChecked.Value)
                {
                    fuel += "Diesel";
                }
                else if (any.IsChecked.Value)
                {
                    fuel += "Others";
                }
                DateTime.TryParse(dom.Date.ToString(), out result);
                string dateFormat = result.ToString("yyyy-MM-dd");
                //start basic validation
                if (cha.Text == "" || seat.Text == "" || fuel == "" 
                    || cap.Text == "" || apply == "" || dateFormat == "" || apply=="")
                {
                    await new MessageDialog("Fields cannot be blank").ShowAsync();

                }
                else
                {
                    if (!flag)
                    {
                        details1.Add("cha1", cha.Text);
                        details1.Add("seat1", seat.Text);
                        details1.Add("fuel", fuel);
                        details1.Add("dom", dateFormat);
                        details1.Add("apply", apply);
                        details1.Add("cap", cap.Text);
                        details1.Add("applydate", applydate);
                        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                        string id = localSettings.Values["id"].ToString();
                        details1.Add("id", id);
                        flag = true;
                    }
                    await AsyncTask(details1);
                    if (RESPONSE.Equals("Registered successfully."))
                    {
                        Frame.Navigate(typeof(Next), "Vehicle");
                    }
                    else
                    {
                        await new MessageDialog(RESPONSE).ShowAsync();
                    }
                }
            }
        }

        private void pet_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void die_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void any_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
