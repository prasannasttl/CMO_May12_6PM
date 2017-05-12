using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace CMO
{
    public class App : Application
    {
		public static int FontSize;


        public static int DeviceWidth;
        public static int DeviceHeight;
        public static string responseflagMessage;
        public static string CatchMessage;
        public static string NoInternetConnectionMessage;
		public App(int _deviceWidth, int _deviceHeight)
		{
			DeviceWidth = _deviceWidth;
			DeviceHeight = _deviceHeight;
			Application.Current.Properties["Language"] = "en";
			Application.Current.Properties["CurrentPage"] = "home";
			AppResources.Culture = new System.Globalization.CultureInfo("en");
			MainPage = new NavigationPage(new CMO.MenuController.MaharashtraCMO());
        }
        /*
		 device names= height * width 
		 4, 4s, ipod touch 4G = 960 * 640 
		 5c, 5s, 5, ipoad touch 5G , SE = 1136 * 640
		 6, 7, 6s = 1334 * 750 
		 6+, 6s+ = 1920 * 1080
		 7+ = 2208 * 1242 
         ipad, ipad2, ipad mini = 1024 * 768
		 ipad air, ipad mini retina  2048 * 1536
		 ipad pro = 2732 * 2048   */
        public static int GetFontSizeSmall()
        {
            #region ios
            if (TargetPlatform.iOS == Device.OS)
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    if (((DeviceHeight * 2) >= 1024) && ((DeviceHeight * 2) < 2048)) return 15; //ipad, ipad2, ipad mini
                    else if (((DeviceHeight * 2) >= 2048) && ((DeviceHeight * 2) < 2732)) return 15; //ipad air, mini retina
                    else if ((DeviceHeight * 2) >= 2732) return 15; // ipad pro
                }
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    if (((DeviceHeight * 2) >= 960) && ((DeviceHeight * 2) < 1136)) return 12; //4, 4s, ipod touch 4G
                    else if (((DeviceHeight * 2) >= 1136) && ((DeviceHeight * 2) < 1334)) return 13; //5c, 5s, 5, ipoad touch 5G , SE					
                    else if (((DeviceHeight * 2) >= 1334) && ((DeviceHeight * 2) < 1920)) return 13; //6, 7, 6s
                    else if (((DeviceHeight * 2) >= 1920) && ((DeviceHeight * 2) < 2248)) return 12; //6+, 6s+
                    else if ((DeviceHeight * 2) >= 2248) return 13; //7+
                }
            }
            #endregion
            #region android
            else if (TargetPlatform.Android == Device.OS)
            {

                if (Device.Idiom == TargetIdiom.Tablet)
                { return 13; }
                else if (Device.Idiom == TargetIdiom.Phone)
                { return 13; }
            }
            #endregion
            return 10;
        }
        public static int GetFontSizeMedium()
        {
            #region ios
            if (TargetPlatform.iOS == Device.OS)
            {
                //if (Device.Idiom == TargetIdiom.Tablet)
                //{ return 16; }
                //else if (Device.Idiom == TargetIdiom.Phone)
                //{ return 12; }
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    if (((DeviceHeight * 2) >= 1024) && ((DeviceHeight * 2) < 2048)) return 16; //ipad, ipad2, ipad mini
                    else if (((DeviceHeight * 2) >= 2048) && ((DeviceHeight * 2) < 2732)) return 16; //ipad air, mini retina
                    else if ((DeviceHeight * 2) >= 2732) return 16; // ipad pro
                }
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    if (((DeviceHeight * 2) >= 960) && ((DeviceHeight * 2) < 1136)) return 14; //4, 4s, ipod touch 4G
                    else if (((DeviceHeight * 2) >= 1136) && ((DeviceHeight * 2) < 1334)) return 14; //5c, 5s, 5, ipoad touch 5G , SE					
                    else if (((DeviceHeight * 2) >= 1334) && ((DeviceHeight * 2) < 1920)) return 14; //6, 7, 6s
                    else if (((DeviceHeight * 2) >= 1920) && ((DeviceHeight * 2) < 2248)) return 14; //6+, 6s+
                    else if ((DeviceHeight * 2) >= 2248) return 14; //7+
                }
            }
            #endregion
            #region android
            else if (TargetPlatform.Android == Device.OS)
            {

                if (Device.Idiom == TargetIdiom.Tablet)
                { return 15; }
                else if (Device.Idiom == TargetIdiom.Phone)
                { return 14; }
            }
            #endregion
            return 10;
        }
        public static int GetFontSizeTitle()
        {
            #region ios
            if (TargetPlatform.iOS == Device.OS)
            {
                //if (Device.Idiom == TargetIdiom.Tablet)
                //{ return 17; }
                //else if (Device.Idiom == TargetIdiom.Phone)
                //{ return 13; }
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    if (((DeviceHeight * 2) >= 1024) && ((DeviceHeight * 2) < 2048)) return 17; //ipad, ipad2, ipad mini
                    else if (((DeviceHeight * 2) >= 2048) && ((DeviceHeight * 2) < 2732)) return 17; //ipad air, mini retina
                    else if ((DeviceHeight * 2) >= 2732) return 17; // ipad pro
                }
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    if (((DeviceHeight * 2) >= 960) && ((DeviceHeight * 2) < 1136)) return 14; //4, 4s, ipod touch 4G
                    else if (((DeviceHeight * 2) >= 1136) && ((DeviceHeight * 2) < 1334)) return 14; //5c, 5s, 5, ipoad touch 5G , SE					
                    else if (((DeviceHeight * 2) >= 1334) && ((DeviceHeight * 2) < 1920)) return 15; //6, 7, 6s
                    else if (((DeviceHeight * 2) >= 1920) && ((DeviceHeight * 2) < 2248)) return 15; //6+, 6s+
                    else if ((DeviceHeight * 2) >= 2248) return 15; //7+
                }
            }
            #endregion
            #region android
            else if (TargetPlatform.Android == Device.OS)
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                { return 17; }
                else if (Device.Idiom == TargetIdiom.Phone)
                { return 15; }
            }
            #endregion
            return 15;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static bool CheckInternetConnection()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (Device.OS == TargetPlatform.Android)
            {
                var networkStatus = networkConnection.IsConnected ? "Connected" : "Not Connected";
                return networkConnection.IsConnected;
            }

            if (Device.OS == TargetPlatform.iOS)
            {
                var ntwrkIOS = CrossConnectivity.Current.IsConnected ? "Connected" : "No Connection";
                return CrossConnectivity.Current.IsConnected;
            }
            return false;
        }
        public static string CurrentPage()
        {
            string _currentPage = "";
            if (Application.Current.Properties.ContainsKey("CurrentPage"))
            { _currentPage = Application.Current.Properties["CurrentPage"] as string; }
            return _currentPage;
        }

        static ContentPage page;
        public App()
        {
			var connectivityButton = new Button
            {
                Text = "Connectivity Test"
            };

            var connected = new Label
            {
                Text = "Is Connected: "
            };

            var connectionTypes = new Label
            {
                Text = "Connection Types: "
            };

            var bandwidths = new Label
            {
                Text = "Bandwidths"
            };

            var host = new Entry
            {
                Text = "127.0.0.1"
            };


            var host2 = new Entry
            {
                Text = "montemagno.com"
            };

            var port = new Entry
            {
                Text = "80",
                Keyboard = Keyboard.Numeric
            };

            var canReach1 = new Label
            {
                Text = "Can reach1: "
            };

            var canReach2 = new Label
            {
                Text = "Can reach2: "
            };


            connectivityButton.Clicked += async (sender, args) =>
            {
                connected.Text = CrossConnectivity.Current.IsConnected ? "Connected" : "No Connection";
                bandwidths.Text = "Bandwidths: ";
                foreach (var band in CrossConnectivity.Current.Bandwidths)
                {
                    bandwidths.Text += band.ToString() + ", ";
                }
                connectionTypes.Text = "ConnectionTypes:  ";
                foreach (var band in CrossConnectivity.Current.ConnectionTypes)
                {
                    connectionTypes.Text += band.ToString() + ", ";
                }

                try
                {
                    canReach1.Text = await CrossConnectivity.Current.IsReachable(host.Text) ? "Reachable" : "Not reachable";

                }
                catch (Exception ex)
                {

                }
                try
                {
                    canReach2.Text = await CrossConnectivity.Current.IsRemoteReachable(host2.Text, int.Parse(port.Text)) ? "Reachable" : "Not reachable";

                }
                catch (Exception ex)
                {

                }


            };


            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                page.DisplayAlert("Connectivity Changed", "IsConnected: " + args.IsConnected.ToString(), "OK");
            };


            // The root page of your application
            MainPage = page = new ContentPage
            {
                Content = new StackLayout
                {
                    Padding = 50,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                          connectivityButton,
                          connected,
                          bandwidths,
                          connectionTypes,
                          host,
                          host2,
                          port,
                          canReach1,
                          canReach2,
                    }
                }
            };
        }
    }
}
