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
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;



namespace RoadTransportFinal
{
   
    public sealed partial class logout : Page
    {
        public logout()
        {
            this.InitializeComponent();
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("You have successfully logged out!!"));
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", "ms-appx:///assets/icon_roadtransport.png");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "roadtransport logo");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["logggedin"] = false;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login.Home));
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }
    }
}
