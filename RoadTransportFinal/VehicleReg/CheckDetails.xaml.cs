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
using System.Diagnostics;
using HtmlAgilityPack;
using Windows.Data.Json;
using System.Net;
using Newtonsoft.Json.Linq;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.VehicleReg
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CheckDetails : Page
    {
        public CheckDetails()
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
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }
        static JObject json;

        static string URL = "http://transportapi.herokuapp.com/details?regno=";
        static async Task AsyncTask(string tax)
        {
            string url = URL + tax;

            Uri signup_uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(signup_uri);
            if (res.IsSuccessStatusCode)
            {
                await new MessageDialog(res.Content.ToString()).ShowAsync();
                json = JObject.Parse(res.Content.ToString());
            }


        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string tax = rtregno.Text;
            //form validation
            if (tax.Equals(""))
            {
                await new MessageDialog("Number cannot be empty").ShowAsync();
            }
            else
            {
                //start the progress ring
                myProgressRing.IsActive = true;
                await AsyncTask(tax);
                myProgressRing.IsActive = false;
                //stop the ring
                if (json != null)
                {
                    taxamount.Text = "Owner Name: " + json.GetValue("ownername");
                    datepaid.Text = "Vehicle Class: " + json.GetValue("vehicleclass");
                    datevalid.Text = "Manufacture Date: " + json.GetValue("mfgdate");
                    makerclass.Text = "Vehicle Class: " + json.GetValue("makerclass");
                    aadhaar.Text = "Aadhaar Number: " + json.GetValue("aadhaar");
                }
                else
                {
                    taxamount.Text = "Some Error. Please check your registration number.";
                }
            }


        }

        //handle click events
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
#if WINDOWS_PHONE_APP
                void HardwareButtons_BackPressed(object sender,
                  Windows.Phone.UI.Input.BackPressedEventArgs e)
                {
                  if (this.Frame != null && this.Frame.CanGoBack)
                  {
                    e.Handled = true;
                    this.Frame.GoBack();
                  }
                }
#endif
    }
}

