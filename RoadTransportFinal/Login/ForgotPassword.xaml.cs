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



namespace RoadTransportFinal.Login
{
   
    public sealed partial class ForgotPassword : Page
    {
        public ForgotPassword()
        {
            this.InitializeComponent();
        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Startup));
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
            //settng.IsEnabled = true;
        }

        private void CommandBar_Opened(object sender, object e)
        {

        }
        private async void Proceed_Click(object sender, RoutedEventArgs e)
        {
            if (otp.IsChecked.Value)
            {
                Frame.Navigate(typeof(Reset.OTP));
            }
            else if (email.IsChecked.Value)
            {
                Frame.Navigate(typeof(Reset.Email));
            }
            else
            {
                await  new MessageDialog("Please select a method").ShowAsync();
            }
        }
    }
}
