using Newtonsoft.Json.Linq;
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


namespace RoadTransportFinal.Login
{
    
    public sealed partial class Login : Page
    {
        
        static string URL = "http://roadtransportdb.azurewebsites.net/signin.php";
        static string OTP_URL = "http://www.smsgatewaycenter.com/library/send_sms_2.php?UserName=krishnapavan96&Password=mThs7kxa&Type=Individual&To=";
        static int OTP_NUM = 0;
        static Boolean basic_login = false;
        static JObject details; 
        static Boolean loggedin = false;
        public Login()
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
        static async Task AsyncTask(CancellationToken cts, Dictionary<string,string> pairs)
        {
            Uri signup_uri = new Uri(URL);
            HttpClient client = new HttpClient();
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {
                
                if (res.Content.ToString().Equals("failed"))
                {
                    loggedin = false;
                }
                else
                {
                    details = JObject.Parse(res.Content.ToString());
                    loggedin = true;
                }
            }
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            blotps.Visibility = Visibility.Visible;
            button.IsEnabled = false;
            blotps.Text = "Verifying Credentials...";
            CancellationTokenSource cts = null;
            //basic form validation
            if (username.Text.Equals("") || password.Password.Equals(""))
            {
                await new MessageDialog("Fields Cannot Be Blank").ShowAsync();
            }
            else
            {
                string message = "";
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("username", username.Text);
                pairs.Add("password", password.Password.ToString());
                //for testing purpose only. Removed for release version.
                if (username.Text.ToString().Equals("admin") && password.Password.ToString().Equals("admin"))
                {
                    message += "Signed in as admin-(Testing)";
                    Frame.Navigate(typeof(Menu.MainMenu), message);
                }
                //create a new Cancellation token (experimental) and then send the request
                else
                {

                    if (cts == null)
                    {
                        cts = new CancellationTokenSource();
                        try
                        {
                            if(!basic_login) await AsyncTask(cts.Token, pairs);
                            if (loggedin)
                            {
                                basic_login = true;
                                if (otp.Visibility == Visibility.Visible)
                                {
                                    string text = otp.Text;
                                    if (Int32.Parse(text) != OTP_NUM && Int32.Parse(text) != 77667)
                                    {
                                        await new MessageDialog("OTP is not valid(use 77667 for testing)").ShowAsync();
                                    }
                                    else
                                    {
                                        message += "Signed in as " + username.Text;
                                        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                                        localSettings.Values["username"] = details.GetValue("username").ToString();
                                        localSettings.Values["email"] = details.GetValue("email").ToString();
                                        localSettings.Values["state"] = details.GetValue("state").ToString();
                                        localSettings.Values["mobile"] = details.GetValue("mobile").ToString();
                                        localSettings.Values["id"] = details.GetValue("id").ToString();
                                        localSettings.Values["loggedin"] = "true";
                                        Frame.Navigate(typeof(Menu.MainMenu), message);
                                    }
                                }
                                else
                                {
                                    //start otp authentication
                                  
                                    await SendOTP(details.GetValue("mobile").ToString());
                                    otp.Visibility = Visibility.Visible;
                                    blotp.Visibility = Visibility.Visible;
                                    blotps.Text = "Enter one time password that is sent your mobile";
                                    button.IsEnabled = true;
                                }

                                    
                            }
                            else
                            {
                                var dialog = new MessageDialog("Invalid Username/ Password");
                                await dialog.ShowAsync();
                            }
                        }
                        catch (OperationCanceledException)
                        {
                        }
                        finally
                        {
                            cts = null;
                        }
                    }
                    else
                    {
                        cts.Cancel();
                        cts = null;
                    }
                }
            }
                
            
            
        }

        private void frgt_pwd_usm_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ForgotPassword));
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
