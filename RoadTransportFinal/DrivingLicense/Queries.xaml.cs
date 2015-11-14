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
    /// A page with list a queries under driving license.
    /// </summary>
    public sealed partial class Queries : Page
    {
        List<string> mylist = new List<string>() { "Learners Details", "Status of Application", "Payment Receipts", "Near-by-RTOS" };
        /// <summary>
        /// Constructor. Initializes the listbox with various query types
        /// </summary>
        public Queries()
        {
            this.InitializeComponent();
            listBox.ItemsSource = mylist;
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
        /// <summary>
        /// Handles the back event of the AppBarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        /// <summary>
        /// Handles the settings event of the AppBarButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
        }

        /// <summary>
        /// Handles the contacts event of the AppBarButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }
        /// <summary>
        /// Handles the event of the AppBarButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {

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
        /// Navigates to a particular query page based on list item selection.
        /// </summary>
        private void listBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            string item = listBox.SelectedItem.ToString();
            if(item.Equals("Learners Details"))
            {
                Frame.Navigate(typeof(DrivingLicense.Sub_Queries.learnerdetail));
            }
            else if (item.Equals("Status of Application"))
            {
                Frame.Navigate(typeof(DrivingLicense.Sub_Queries.SOA));
            }
            else if (item.Equals("Payment Receipts"))
            {
                Frame.Navigate(typeof(DrivingLicense.Sub_Queries.Recipts));
            }
            else if (item.Equals("Near-by-RTOS"))
            {
                Frame.Navigate(typeof(DrivingLicense.Sub_Queries.NR));
            }
            else
            {

            }


        }

        /// <summary>
        /// Handles the go to Main Menu  event of the AppBarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }
    }
}
