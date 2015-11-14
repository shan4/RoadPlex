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



namespace RoadTransportFinal.DrivingLicense
{


    /// <summary>
    /// Class Services. A class template about the services offered
    /// </summary>
    public sealed partial class Services : Page
    {

        /// <summary>
        /// The list of items to be added
        /// </summary>
        List<string> mylist = new List<string>() { "Learners Registration", "Renewal",
              "Slot Booking" };

        /// <summary>
        /// Initializes a new instance of the <see cref="Services"/> class.
        /// </summary>
        public Services()
        {
            this.InitializeComponent();
            listBox.ItemsSource = mylist;
            
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
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
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
        /// Handles the SelectionChanged event of the listBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = listBox.SelectedItem.ToString();
            if(item.Equals("Learners Registration"))
            {
                Frame.Navigate(typeof(DrivingLicense.Sub_Services.LearnersRegistration));
            }
            else if(item.Equals("Renewal"))
            {
                Frame.Navigate(typeof(DrivingLicense.Sub_Services.Renewal));
            }
            
           
            else
            {
                Frame.Navigate(typeof(DrivingLicense.Sub_Services.SlotBooking));
            }
        }

        /// <summary>
        /// Handles the main menu event of the AppBarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }
    }
}
