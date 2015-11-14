using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace RoadTransportFinal.VehicleReg.Sub_service
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Slot1 : Page
    {
        static string response = "";
        static string SLOT_URL = "http://roadtransportdb.azurewebsites.net/vhbook.php";
        public ObservableCollection<Bindings.CheckedListItem1<Bindings.Slot1>> MySlots = new ObservableCollection<Bindings.CheckedListItem1<Bindings.Slot1>>();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Bindings.Slot1> parameter = e.Parameter as List<Bindings.Slot1>;
            foreach (Bindings.Slot1 bl in parameter)
            {
                MySlots.Add(new Bindings.CheckedListItem1<Bindings.Slot1>(bl));
            }
        }
        public Slot1()
        {
            this.InitializeComponent();
            DataContext = this;
            ListBox1.ItemsSource = MySlots;
        }
        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
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
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logout));
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
        private async void checkB_Click(object sender, RoutedEventArgs e)
        {
            string slot_id = slotid.Text;
            string email = usere.Text;
            bool isCorrect = false;
            foreach (var p in MySlots)
            {
                if (p.Item.Id.Equals(slot_id) && p.Item.Status.Equals("FREE"))
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
                await AsyncTask(pairs);
                await new MessageDialog(response).ShowAsync();
            }
        }
    }
}
