using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RoadTransportFinal.DrivingLicense.Sub_Services
{

    /// <summary>
    /// Class SlotConfirmation. A page used to confirm the driving slot of the user
    /// </summary>
    public sealed partial class SlotConfirmation : Page
    {
        static string flag;
        static string response = "";
        static string SLOT_URL = "http://roadtransportdb.azurewebsites.net/dlbook.php";
        public ObservableCollection<Bindings.CheckedListItem<Bindings.Slot>> MySlots = new ObservableCollection<Bindings.CheckedListItem<Bindings.Slot>>();

        /// <summary>
        /// Handles the <see cref="E:NavigatedTo" /> event. Creates a binding of checked list items received from slotbooking
        /// </summary>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Object> mylist = e.Parameter as List<Object>;
            List<Bindings.Slot> parameter = mylist.ElementAt(0) as List<Bindings.Slot>;
            if(mylist.Count == 2)
            {
                flag = mylist.ElementAt(1) as string;
            }
            foreach (Bindings.Slot bl in parameter)
            {
                MySlots.Add(new Bindings.CheckedListItem<Bindings.Slot>(bl));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotConfirmation"/> class.
        /// </summary>
        public SlotConfirmation()
        {
            this.InitializeComponent();
            DataContext = this;
            ListBox1.ItemsSource = MySlots;
        }
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }

        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }

        private void TextBlock_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
        }

        private void TextBlock_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }

        private void TextBlock_Tapped_4(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Settings));
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Contacts));
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.Personal));
        }
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
        }
        private void CommandBar_Opened(object sender, object e)
        {

        }
        private void AppBarButton_Click6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu.MainMenu));
        }

        /// <summary>
        /// Asynchronouses the task. Post request to the azure webservice and parses the response
        /// </summary>
        /// <param name="pairs">The pairs.</param>
        /// <returns>Task.</returns>
        static async Task AsyncTask(Dictionary<string, string> pairs)
        {
            Uri signup_uri = new Uri(SLOT_URL);
            HttpClient client = new HttpClient();
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage res = await client.PostAsync(signup_uri, content);
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ToString();

            }
        }

        /// <summary>
        /// Handles the Click event of the checkB control. Validates, adds data to dictionary and then calls the async task.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void checkB_Click(object sender, RoutedEventArgs e)
        {
            string slot_id = slotid.Text;
            string email = usere.Text;
            bool isCorrect = false;
            foreach(var p in MySlots)
            {
                if(p.Item.Id.Equals(slot_id) && p.Item.Status.Equals("FREE"))
                {
                    isCorrect = true;
                    break;
                }
            }
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string hisemail = localSettings.Values["email"].ToString();
            if (!isCorrect || email.Equals(""))
            {
               await new MessageDialog("Please enter valid slot id and email ").ShowAsync();
            }
            else if (!email.Equals(hisemail))
            {
                await new MessageDialog("Entered email address doesnt match with the registered address ").ShowAsync();
            }
            else
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("id", slot_id);
                pairs.Add("email", email);
                if (flag != null)
                    pairs.Add("flag", flag);
                else
                    pairs.Add("flag", "false");
                await AsyncTask(pairs);
                await new MessageDialog(response).ShowAsync();
            }
        }
        
    }
}
