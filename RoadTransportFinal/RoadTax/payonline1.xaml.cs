using RoadTransportFinal.Bindings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.RoadTax
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class payonline1 : Page
    {
        static string URL = "http://roadtransportdb.azurewebsites.net/roadtax/rtpayment.php";
        public payonline1()
        {
            this.InitializeComponent();
            ring.IsActive = false;
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

        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = { vhclnum.Text, chsnum.Text, comboBox.SelectedValue.ToString(), ownname.Text };
            bool flag = true;
            foreach(var p in arr)
            {
                if(p == "")
                {
                    await new MessageDialog("Fields cannot be blank").ShowAsync();
                    flag = false;
                }
            }
            if(flag)
            {
                Dictionary<string, string> details = new Dictionary<string, string>();
                details.Add("vhno", vhclnum.Text);
                details.Add("state", comboBox.SelectedValue.ToString());
                details.Add("owname", ownname.Text);
                details.Add("chassis", chsnum.Text);
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string id = localSettings.Values["id"].ToString();
                details.Add("id", id);
                HttpPostRequest req = new HttpPostRequest();
                ring.IsActive = true;
                button.Visibility = Visibility.Collapsed;
                await req.PostAsync(URL, details);
                ring.IsActive = false;
                button.Visibility = Visibility.Visible;
                if(! req.response.Equals(HttpPostRequest.NETWORK_ERROR))
                {
                    if (req.response.Equals("Done."))
                        Frame.Navigate(typeof(Payement.payement));
                    else
                        await new MessageDialog("Payment Failed. Check Your details and try again").ShowAsync();
                }
            }
            
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
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
    }
}
