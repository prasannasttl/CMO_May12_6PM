using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Globalization;
namespace CMO.MenuController
{
    public partial class NewsFeedTabbedPage : TabbedPage
    {
        public NewsFeedTabbedPage()
        {
            InitializeComponent();
            Title = AppResources.LNewsFeed;
           
            ItemsSource = NewsFeedDataModel.All;

           
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new SideMenu();
            return true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Application.Current.Properties["CurrentPage"] = "newsfeed";
        }
    }

    public class NewsFeedDataModel
    {
        public string FeedURL { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public static IList<NewsFeedDataModel> All { set; get; }

        static NewsFeedDataModel()
        {
            All = new ObservableCollection<NewsFeedDataModel>();
            var twitterfeed = new NewsFeedDataModel();
            twitterfeed.FeedURL = "https://mobile.twitter.com/CMOMaharashtra/favorites";
            twitterfeed.Name = "Twitter";
            twitterfeed.Icon = "tabtwit.png";
            var fbfeed = new NewsFeedDataModel();
            fbfeed.FeedURL = "https://m.facebook.com/CMOMaharashtra";
            fbfeed.Name = "FaceBook";
            fbfeed.Icon = "tabfb.png";
            var youtubefeed = new NewsFeedDataModel();
            youtubefeed.FeedURL = "https://www.youtube.com/";
            youtubefeed.Name = "YouTube";
            youtubefeed.Icon = "tabutube.png";

            All.Add(twitterfeed);
            All.Add(fbfeed);
            All.Add(youtubefeed);
        }
    }
}
