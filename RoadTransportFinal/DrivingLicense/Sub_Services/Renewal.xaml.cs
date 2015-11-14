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

namespace RoadTransportFinal.DrivingLicense.Sub_Services
{

    /// <summary>
    /// Class Renewal. A page for renewal service.
    /// </summary>
    public sealed partial class Renewal : Page
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Renewal"/> class.
        /// </summary>
        public Renewal()
        {
            this.InitializeComponent();
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
        /// <summary>
        /// Handles the Click event of the nextr control. Parses the values, validates, adds the fields and navigates to part2.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void nextr_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateValue;
            string dateFormat, dateFormat1, dateFormat2;
            try
            {
                dateValue = DateTime.Parse(doi.Date.ToString());
                 dateFormat = dateValue.ToString("yyyy-MM-dd");
                dateValue = DateTime.Parse(dor.Date.ToString());
                dateFormat1 = dateValue.ToString("yyyy-MM-dd");
                dateValue = DateTime.Parse(doe.Date.ToString());
                dateFormat2 = dateValue.ToString("yyyy-MM-dd");
            }catch(Exception ef)
            {
                dateFormat1 = "";
                dateFormat2 = "";
                dateFormat = "";
            }
            //start form validation
            if (dlnum.Text == "" || auth.Text == "" ||
                auth1.Text == "" || num.Text == "" || dateFormat == "" || dateFormat1 == "" || dateFormat2 == "")
            {
                await new MessageDialog("Fields cannot be blank").ShowAsync();
            }
            else
            {
                //create a holder for all the items and pass to the next page
                Dictionary<string, string> details = new Dictionary<string, string>();
                details.Add("dlnum", dlnum.Text);
                details.Add("doi", dateFormat);
                details.Add("auth", auth.Text);
                details.Add("auth1", auth1.Text);
                details.Add("dor", dateFormat1);
                details.Add("doe", dateFormat2);
                details.Add("num", num.Text);
                Frame.Navigate(typeof(Renewal1), details);
            }


        }
    }
 }

