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
using Windows.Web.Http;
using Windows.UI.Popups;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.Login.Reset
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResetByOTP : Page
    {
        static string RESPONSE = "";
        static string MOBILE = "";
        static string URL = "http://roadtransportdb.azurewebsites.net/resetbyotp.php";
        public ResetByOTP()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MOBILE = e.Parameter as string;
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
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (cpassword.Password.Equals(password.Password))
            {
                if (cpassword.Password == "")
                {
                    await new MessageDialog("Password cannot be blank").ShowAsync();
                }
                else
                {
                    Dictionary<string, string> vals = new Dictionary<string, string>();
                    vals.Add("mobile", MOBILE);
                    vals.Add("password", cpassword.Password);
                    button.IsEnabled = false;
                    await AsyncTask(vals);
                    if(RESPONSE.Equals("Success."))
                    {
                        await new MessageDialog("Password changed successfully. You can login now").ShowAsync();
                        Frame.Navigate(typeof(Login));
                    }
                    else
                    {
                        await new MessageDialog("Server error! Try again later").ShowAsync();
                        button.IsEnabled = true;
                    }
                }
            }
            else
            {
                await new MessageDialog("Passwords do-not match").ShowAsync();
            }

        }
        static async Task AsyncTask(Dictionary<string, string> pairs)
        {
            //setup http client
            Uri signup_uri = new Uri(URL);
            HttpClient client = new HttpClient();
            //put form data
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);

            //get response
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {
                //store response in string
                RESPONSE = res.Content.ToString();
            }

        }
    }
}
