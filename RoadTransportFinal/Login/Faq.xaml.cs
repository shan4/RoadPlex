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

namespace RoadTransportFinal.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Faq : Page
    {
        List<string> mylist = new List<string> { "Do I have to register to avail the services?", "Are there any registration charges for creating an account?", "What should I do if I have trouble with logging in?", "Should I be concerned with the privacy of my personal details I have shared with the app?", "What if I have additional questions?" };

        public Faq()
        {
            this.InitializeComponent();
            listBox.ItemsSource = mylist;

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

        private void CommandBar_Opened(object sender, object e)
        {

        }
        private async void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             string item = listBox.SelectedItem.ToString();
            if  (item.Equals("Do I have to register to avail the services?"))
            {
               await new MessageDialog("Yes, you must register to avail our services. This would help you to store your information with us and you do not have to enter your details everytime you use this app.").ShowAsync();

            }

            else if (item.Equals("Are there any registration charges for creating an account?"))
            {
                await new MessageDialog("No, there are no registration charges applicable for creating an account with us. It is absolutely free of cost.").ShowAsync();
            }
            else if (item.Equals("What should I do if I have trouble with logging in?"))

            {
                await new MessageDialog("Follow these instructions if you face an issue logging in: Check your login details. Make sure your username and password should match with the signup credentials. If you have forgotten your password, reset your password using the ‘Forgot your Password’ link on the sign-in page. If you are still unable to access your account, please contact us. We will resolve the issue at the earliest.").ShowAsync();
            }
            else if (item.Equals("Should I be concerned with the privacy of my personal details I have shared with the app?"))
            {
                await new MessageDialog("Do not worry! We are absolutely committed to safeguarding your personal information. The personal information collected is to validate your identity, as well as to provide us with a way to get in touch with you if the need should arise. We follow strict security procedures in the storage and disclosure of information which you have given us, to prevent unauthorised access. We do not pass on, trade or sell your personal information to anyone.").ShowAsync();
            }
            else if (item.Equals("What if I have additional questions?"))
            {
               await new MessageDialog("If you have any additional questions, comments or other general customer service inquiries, please submit your query using contact us link. We will resolve the issue at the earliest.").ShowAsync();
            }

            else
            {

            }
        }
    }
}