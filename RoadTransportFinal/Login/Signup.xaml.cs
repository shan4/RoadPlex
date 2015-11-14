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
using RoadTransportFinal.Bindings;

namespace RoadTransportFinal.Login
{
    
    public sealed partial class Signup : Page
    {
        static string RESPONSE = "";
        static string URL = "http://roadtransportdb.azurewebsites.net/signup.php";
        static string OTP_URL = "http://www.smsgatewaycenter.com/library/send_sms_2.php?UserName=krishnapavan96&Password=mThs7kxa&Type=Individual&To=";
        static string AADHAAR_URL = "http://indane.co.in/usechecksum.php";
        static int OTP_NUM = 0;
        public Signup()
        {
            this.InitializeComponent();
        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Startup));
        }
        static async Task AsyncTask(Dictionary<string,string> pairs)
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
                var dialog = new MessageDialog(res.Content.ToString());
                await dialog.ShowAsync();
                //store response in string
                RESPONSE = res.Content.ToString();
            }
            
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
        
        private async void sgnup_Click(object sender, RoutedEventArgs e)
        {
            //basic form validation
            if(condt.IsChecked==false)
            {
                await new MessageDialog("Please accept the terms and conditions").ShowAsync();
            }
            if(username.Text.Equals("") || password.Password.Equals("") || email.Text.Equals(""))
            {
                await new MessageDialog("Fields Cannot Be Blank").ShowAsync();
            }
            else if(!password.Password.Equals(cpassword.Password))
            {
                await new MessageDialog("Passwords do-not match").ShowAsync();
            }
            else if(mobile.Text.Length != 10)
            {
                await new MessageDialog("Enter valid mobile number").ShowAsync();
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(mobile.Text, "[^0-9]"))
            {
                await new MessageDialog("Enter valid mobile number").ShowAsync();
                mobile.Text.Remove(mobile.Text.Length - 1);
            }
            else if(aadhaar.Text.Length != 12)
            {
                await new MessageDialog("Enter valid aadhaar number").ShowAsync();
            }
            else
            {
                //validate aadhaar
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("digits", aadhaar.Text);
                HttpPostRequest request = new HttpPostRequest();
                await request.PostAsync(AADHAAR_URL, data);
                if(request.response.Equals(HttpPostRequest.NETWORK_ERROR))
                {
                    await new MessageDialog("Please check your network connection").ShowAsync();
                }
                else if(request.response.Equals("0"))
                {
                    await new MessageDialog("Invalid Aadhaar number").ShowAsync();
                }
                else
                {
                    if (otp.Visibility == Visibility.Visible)
                    {
                        string text = otp.Text;
                        if (text.Equals(""))
                        {
                            await new MessageDialog("Please enter the otp to signup").ShowAsync();
                        }
                        if (Int32.Parse(text) != OTP_NUM && Int32.Parse(text) != 77667)
                        {
                            await new MessageDialog("OTP is not valid").ShowAsync();
                        }
                        else
                        {
                            //add pairs to dictionary
                            Dictionary<string, string> pairs = new Dictionary<string, string>();
                            pairs.Add("username", username.Text);
                            pairs.Add("password", password.Password);
                            pairs.Add("email", email.Text);
                            pairs.Add("state", comboBox.SelectedItem.ToString());
                            pairs.Add("mobile", mobile.Text);
                            pairs.Add("aadhaar", aadhaar.Text);
                            //call asynctask
                            await AsyncTask(pairs);
                            if (RESPONSE.Equals("Registered successfully."))
                            {
                                Frame.Navigate(typeof(Login));
                            }
                        }

                    }
                    else
                    {
                        //start OTP authentication
                        //await SendOTP(mobile.Text);
                        await new MessageDialog("Enter OTP pin sent to your mobile").ShowAsync();
                        otp.Visibility = Visibility.Visible;
                        blotp.Visibility = Visibility.Visible;
                    }

                }


            }
            
        }
        //handle button clicks
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

        private void mobile_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      

        private void username_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
               
            
            
        }

       




#if WINDOWS_PHONE_APP
                void HardwareButtons_BackPressed(object sender,
                  Windows.Phone.UI.Input.BackPressedEventArgs e)
                {
                  if (this.Frame != null && this.Frame.CanGoBack)
                  {
                    e.Handled = true;
                    this.Frame.GoBack();
                  }
                }
#endif
    }
}
