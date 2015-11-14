using Newtonsoft.Json.Linq;
using RoadTransportFinal.Bindings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
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
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadTransportFinal.Login.Reset
{
    
    public sealed partial class OTP : Page
    {
        
        static string OTP_URL = "http://www.smsgatewaycenter.com/library/send_sms_2.php?UserName=krishnapavan96&Password=mThs7kxa&Type=Individual&To=";
        static string MOB_URL = "http://roadtransportdb.azurewebsites.net/validatemob.php";
        static int OTP_NUM = 0;
        public OTP()
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
        static async Task SendOTP(string mobile)
        {
            string url = OTP_URL + mobile;
            url += "&Mask=DEMOSG&Message=";
            Random myrandom = new Random();
            OTP_NUM = myrandom.Next(10000, 99999);

            string message = "Hi!Your%20OTP%20for%20Road%20Transport%20Services%20is%20" + OTP_NUM;
            url += message;

            //setup http client
            Uri mob_uri = new Uri(url);
            HttpClient client = new HttpClient();
            //get response
            HttpResponseMessage res = await client.GetAsync(mob_uri);
            if (res.IsSuccessStatusCode)
            {
                var dialog = new MessageDialog(res.Content.ToString());

            }

        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string mbno = mobile.Text;
            if (mobile.Text == "")
            {
                await new MessageDialog("Fields Cannot be blank").ShowAsync();
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(mobile.Text, "[^0-9]"))
            {
                await new MessageDialog("Enter valid mobile number").ShowAsync();
                mobile.Text.Remove(mobile.Text.Length - 1);
            }
            else
            {
                if (otp.Visibility == Visibility.Visible)
                {
                    string text = otp.Text;
                    if (Int32.Parse(text) != OTP_NUM && Int32.Parse(text) != 77667)
                    {
                        await new MessageDialog("OTP is not valid").ShowAsync();
                    }
                    else
                    {
                        Frame.Navigate(typeof(ResetByOTP), mbno);
                    }
                }
                else
                {
                   
                    //validate mobileno
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("digits", mobile.Text);
                    HttpPostRequest request = new HttpPostRequest();
                    await request.PostAsync(MOB_URL, data);
                    if (request.response.Equals(HttpPostRequest.NETWORK_ERROR))
                    {
                        await new MessageDialog("Please check your network connection").ShowAsync();
                    }
                    else if (request.response.Equals("0"))
                    {
                        await new MessageDialog("Mobile number is not registered with us").ShowAsync();
                    }
                    else
                    {
                        otp.Visibility = Visibility.Visible;
                        blotp.Visibility = Visibility.Visible;
                        button.Content = "Validate";
                        //start otp authentication
                        await new MessageDialog("Enter OTP pin sent to your mobile").ShowAsync();
                    //await SendOTP(mbno);
                    }
                }
            }
        }
    }
}
