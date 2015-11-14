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

namespace RoadTransportFinal.DrivingLicense
{
    
    public sealed partial class TestWebView : Page
    {
        public TestWebView()
        {
            this.InitializeComponent();
        }

        private async void MyButton_Click_1(object sender, RoutedEventArgs e)
        {
            await MyWebview.InvokeScriptAsync("TimeUpdate", null);
        }
        private void MyWebview_ScriptNotify_1(object sender, NotifyEventArgs e)
        {
            MyTextBox.Text = e.Value;
        }

    }
}
