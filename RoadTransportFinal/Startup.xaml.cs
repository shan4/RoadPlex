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

namespace RoadTransportFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Startup : Page
    {
        public Startup()
        {
            this.InitializeComponent();
            
            _timer = new DispatcherTimer
            {
                //Set the interval between ticks (in this case 2 seconds to see it working)
                Interval = TimeSpan.FromSeconds(3)
            };

            //Change what's displayed when the timer ticks
            _timer.Tick += ChangeImage;
            //Start the timer
            _timer.Start();
        }

        private void intro_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ChangeImage(object sender, object o)
        {
            
            //Get the number of items in the flip view
            var totalItems = flipView1.Items.Count;
            //Figure out the new item's index (the current index plus one, if the next item would be out of range, go back to zero)
            var newItemIndex = (flipView1.SelectedIndex + 1) % totalItems;
            //Set the displayed item's index on the flip view
            flipView1.SelectedIndex = newItemIndex;
        }




        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login.Home));
        }

        private void in_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private readonly DispatcherTimer _timer;

        //Make a place to store the last time the displayed item was set
        private DateTime _lastChange;
        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FlipView flipView1 = new FlipView();
            flipView1.Items.Add("Item 1");
            flipView1.Items.Add("Item 2");
            flipView1.Items.Add("Item 3");
            flipView1.Items.Add("Item 4");
            flipView1.Items.Add("Item 5");
            flipView1.SelectionChanged += FlipView_SelectionChanged;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void DisplayedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            //Show the time deltas...
            var currentTime = DateTime.Now;

            

            _lastChange = currentTime;

            //Since the page is configured before the timer is, check to make sure that we've actually got a timer
            if (!ReferenceEquals(_timer, null))
            {
                _timer.Stop();
                _timer.Start();
            }
        }
    }
}
