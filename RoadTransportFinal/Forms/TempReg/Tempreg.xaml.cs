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

namespace RoadTransportFinal.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class tempreg : Page
    {
        static Dictionary<string, string> details1;
        public tempreg()
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
        string reg = "";
        DateTime result;
        async private void next_Click(object sender, RoutedEventArgs e)
        {
            DateTime.TryParse(dob.Date.ToString(), out result);
            string dateFormat = result.ToString("yyyy-MM-dd");
           
            //start form validation
            if (fname.Text == "" || pan.Text == "" ||
                 faname.Text == "" || dateFormat == "" || add.Text == "" || dealer.SelectedItem.ToString() == "" || pincode.Text == "")
            {
                await new MessageDialog("Fields cannot be blank").ShowAsync();
            }
            else
            {
                
                if(gender.IsChecked.Value)
                {
                    reg = "female";
                }
                else if(gender1.IsChecked.Value)
                {
                    reg = "male";
                }
                else
                {
                    await new MessageDialog("Please select gender").ShowAsync();
                }
                //create a holder for all the items and pass to the next page
                Dictionary<string, string> details1 = new Dictionary<string, string>();
                details1.Add("fname", fname.Text);
                details1.Add("dob", dateFormat);
                details1.Add("pan", pan.Text);
                details1.Add("add", add.Text);
                details1.Add("dealer", dealer.SelectedItem.ToString());
                details1.Add("faname", faname.Text);
                details1.Add("gender", reg);
                details1.Add("pincode", pincode.Text);
                Frame.Navigate(typeof(TempReg.Continue), details1);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void gender_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
