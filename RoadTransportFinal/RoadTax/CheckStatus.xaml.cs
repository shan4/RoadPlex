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


namespace RoadTransportFinal.RoadTax
{
    
    public sealed partial class CheckStatus : Page
    {
        static string URL = "http://transportapi.herokuapp.com/tax?regno=";
        public CheckStatus()
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
        static JObject json;
        

        static async Task AsyncTask(string tax)
        {
            string url = URL + tax;
            
            Uri signup_uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(signup_uri);
            if (res.IsSuccessStatusCode)
            {
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
                    taxamount.Text = "Tax Amount: " + json.GetValue("taxamount");
                    datepaid.Text = "Date Paid: " + json.GetValue("datepaid");
                    datevalid.Text = "Date Valid: " + json.GetValue("datevalid");
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

