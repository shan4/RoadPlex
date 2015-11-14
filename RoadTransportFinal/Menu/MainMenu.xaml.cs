using RoadTransportFinal.Payement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        static string username = "";
        public MainMenu()
        {
            this.InitializeComponent();
       
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            
                username = localSettings.Values["username"].ToString();
                username += localSettings.Values["id"].ToString();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DrivingLicense.Overview));
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(vehiclereg.Overview));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RoadTax.Overview));
           
        }
        
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PollutionCheck.Overview));
        }

        

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
            
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }

        private async void MyDetails(object sender, RoutedEventArgs e)
        {
            
            MessageDialog mdm = new MessageDialog(username);
            await mdm.ShowAsync();
        }
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("loggedin");
            Frame.Navigate(typeof(logout));
        }
        private void CommandBar_Opened(object sender, object e)
        {
            
        }

        private void AppBarButton_Click_5(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Payement.Saved));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Saved));
        }
    }
}
