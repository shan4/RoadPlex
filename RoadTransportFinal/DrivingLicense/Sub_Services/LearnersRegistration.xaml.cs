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



namespace RoadTransportFinal.DrivingLicense.Sub_Services
{
    /// <summary>
    /// A page about learner registration part 1
    /// </summary>
    public sealed partial class LearnersRegistration : Page
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LearnersRegistration"/> class.
        /// </summary>
        public LearnersRegistration()
        {
            this.InitializeComponent();
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

        /// <summary>
        /// Handles the personal event of the AppBarButton_Click control.
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
        /// Commands the bar_ opened.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void CommandBar_Opened(object sender, object e)
        {

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

        /// <summary>
        /// Checks the form details validates, adds values to dictionary, navigates to part 2. Event fired on button click 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void next_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateValue;
            string dateFormat;
            try
            {
                dateValue = DateTime.Parse(dob.Date.ToString());
                 dateFormat = dateValue.ToString("yyyy-MM-dd");
            }catch(Exception ef)
            {
                dateFormat = "";
            }
            string sex = "";
            if (Male.IsChecked.Value) sex = "male";
            else sex = "female"; 
            //start form validation
            if (fname.Text == "" || sex == "" || education.Text == "" ||
                father.Text == "" || id1.Text == "" || id2.Text == "" || dateFormat == "")
            {
                await new MessageDialog("Fields cannot be blank").ShowAsync();
            }
            else
            {
                //create a holder for all the items and pass to the next page
                Dictionary<string, string> details = new Dictionary<string, string>();
                details.Add("fname", fname.Text);
                details.Add("father", father.Text);
                details.Add("dob", dateFormat);
                details.Add("id1", id1.Text);
                details.Add("id2", id2.Text);
                details.Add("sex", sex);
                details.Add("education", education.Text);
                Frame.Navigate(typeof(LearnersRegistration1), details);
            }
            
        }
    }
}
