using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace App1 {
    public sealed partial class FirstPage : App1.Common.LayoutAwarePage {
        DispatcherTimer dispatcherTimer;
        int count = 0;
        int timesTicked = 0;
        int timesToTick = 1;
        String mode = "menu"; // mode: menu / preview / waiting

        // initialize page
        public FirstPage() {
            this.InitializeComponent();
            DispatcherTimerSetup();
        }


        // setup timer
        public void DispatcherTimerSetup() {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1); // 1 sec
        }

        // highli 
        // used later for previewing colors
        public void highlightButton(int color) {
            var redBrush = new SolidColorBrush(ColorHelper.FromArgb(255, 255, 60, 60));
            greenButton.Background = redBrush;
        }

        void dispatcherTimer_Tick(object sender, object e) {
            timesTicked++;
            if (timesTicked > timesToTick) {
                log.Text = "time = " + (count++).ToString();
                
                // reset timer
                // TODO: check if all colors were shown, then change mode
                dispatcherTimer.Stop();
                timesToTick = 1;
                dispatcherTimer.Start();
            }
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState) {
        }

        protected override void SaveState(Dictionary<String, Object> pageState) {
        }

        // Hyperlink to second page
        private void about(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MainPage));
        }

        // colors
        private void startClick(object sender, RoutedEventArgs e) {
            dispatcherTimer.Start();
            mode = "preview";
            log.Text = "Mode changed to preview.";
        }

        private void greenClick(object sender, RoutedEventArgs e) {

        }
        private void redClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void yellowClick(object sender, RoutedEventArgs e)
        {

        }
        private void blueClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
