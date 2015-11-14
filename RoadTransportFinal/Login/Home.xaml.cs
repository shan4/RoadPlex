using RoadTransportFinal.Menu;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }

        

        private void signIn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void signUp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Signup));
        }

        private void about_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }
        private void faq_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Faq));
        }
        /* private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
         {
             Frame.Navigate(typeof(Menu.Settings));
         }
         */
        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }
        private void CommandBar_Opened(object sender, object e)
        {

        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Startup));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DrivingLicense.TestWebView));
        }

        
    }
}
