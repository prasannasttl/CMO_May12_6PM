using CMO.Gallery;
using CMO.MenuController;
using CMO.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO
{
    public partial class ComingSoonPage : ContentPage
    {
        int widthdevice;
        int deviceheight;
        public string SearchFilterText = "";
        int index = 0;
        int totalItems = 0;
        int totalListItems = 0;
        decimal MaxIndex = 0;
        ObservableCollection<Pressrelease> PressReleaseList;
        public ComingSoonPage()
        {
            InitializeComponent();
            this.Title = AppResources.LPressRelease.ToUpper();
            NavigationPage.SetBackButtonTitle(this, "");

            FilterPressList.FontSize = App.GetFontSizeMedium();
            lblNoRecord.FontSize = App.GetFontSizeMedium();
            lblNoRecord.IsVisible = false;
            #region Design xaml from backend

            deviceheight = App.DeviceHeight;
            widthdevice = App.DeviceWidth;
            #endregion
            #region Event List events
            lstPressRelease.ItemTapped += LstPressRelease_ItemTapped;
            lstPressRelease.ItemAppearing += LstPressRelease_ItemAppearing;
            lstPressRelease.Refreshing += LstPressRelease_Refreshing;
            #endregion
        }

        private async void LstPressRelease_Refreshing(object sender, EventArgs e)
        {
            index = 0;
            loadingIndicator.IsVisible = false;
            loading.IsVisible = false;
            loading.IsRunning = false;
            if (lblNoRecord.IsVisible == true)
            {
                SearchFilterText = "";
                FilterPressList.Text = "";
            }
            lblNoRecord.IsVisible = false;
            await CallWebServiceForPressRelease(index);
        }
        private async void LstPressRelease_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                if (totalItems != 0)
                {
                    MaxIndex = Math.Ceiling(((decimal)totalListItems) / 5);
                    if (index < MaxIndex)
                    {
                        if (PressReleaseList != null && e.Item != null && e.Item == PressReleaseList[PressReleaseList.Count - 1])
                        {
                            index++;
                            if (index != MaxIndex)
                            {
                                loadingIndicator.IsVisible = true;
                                loading.IsVisible = true;
                                loading.IsRunning = true;

                                await CallWebServiceForPressRelease(index);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (App.CurrentPage() == "pressrelease")
                    await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);

            }
        }

        private void LstPressRelease_ItemTapped(object sender, ItemTappedEventArgs e)
        {
                var selectedItem = sender as Xamarin.Forms.ListView;
                var PressItem = selectedItem.SelectedItem as Event;
        }
        public async void TapSearchImage(object sender, EventArgs args)
        {
            lblNoRecord.IsVisible = false;
            if (loading.IsRunning == false)
            {
                if (!App.CheckInternetConnection())
                {
                    await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
                }
                else
                {
                    if (FilterPressList.Text == "" || FilterPressList.Text == null)
                    { SearchFilterText = ""; }
                    else
                    {
                        SearchFilterText = FilterPressList.Text;
                    }
                    index = 0;
                    loadingIndicator.IsVisible = true;
                    loading.IsRunning = true;
                    loading.IsVisible = true;
                    PressReleaseList.Clear();
                    //EventGroupedList.Clear();
                    await CallWebServiceForPressRelease(index);
                }
            }
        }
        public async Task CallWebServiceForPressRelease(int index)
        {
            FilterPressList.IsEnabled = false;
            if (!App.CheckInternetConnection())
            {
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            }
            else
            {
                try
                {
                    #region Key value pairs
                    string lang = "";
                    if (Application.Current.Properties.ContainsKey("Language"))
                    { lang = Application.Current.Properties["Language"] as string; }
                    List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("lang", lang));
                    values.Add(new KeyValuePair<string, string>("title", SearchFilterText));
                    values.Add(new KeyValuePair<string, string>("index", Convert.ToString(index)));
                    if (Device.Idiom == TargetIdiom.Phone)
                    { values.Add(new KeyValuePair<string, string>("limit", "7")); }
                    else
                    { values.Add(new KeyValuePair<string, string>("limit", "10")); }
                    //lang=en&title=&index=0&limit=10
                    #endregion
                    var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectPressRelease>(CMO.ServiceLayer.ServiceLinks.PressRelease_ListURL, values);
                    if (response != null)
                    {
                        if (response._resultflag == 1)
                        {
                            totalItems = response.total_results;
                            totalListItems = response.search_results;
                            var x = lstPressRelease.RowHeight;
                            if (PressReleaseList == null || index == 0)
                            {
                                PressReleaseList = new ObservableCollection<Pressrelease>();
                                //EventGroupedList = new ObservableCollection<GroupedEventListModel>();
                                //TodayGrouped = new GroupedEventListModel() { LongName = "Today", ShortName = "v" };
                                //TomorrowGrouped = new GroupedEventListModel() { LongName = "Tomorrow", ShortName = "f" };
                            }
                            for (int i = 0; i < response.pressreleaselist.Count; i++)
                            {
                                var ObjectPress = new Pressrelease();

                                ObjectPress.SetFontSize = App.GetFontSizeMedium();
                                DateTime oDate = Convert.ToDateTime(response.pressreleaselist[i].date);
                                response.pressreleaselist[i].date = oDate.ToString("MMM. dd, yyyy");
                                ObjectPress.date = response.pressreleaselist[i].date;
                                ObjectPress.file_path = response.pressreleaselist[i].file_path;
                                ObjectPress.title = response.pressreleaselist[i].title;
                                ObjectPress.content = response.pressreleaselist[i].content;
                                PressReleaseList.Add(ObjectPress);

                            }
                            #region (Row Height) Specific Design implemention for phone and tablet
                            if (Device.Idiom == TargetIdiom.Phone)
                            { lstPressRelease.RowHeight = 100; }
                            else if (Device.Idiom == TargetIdiom.Tablet)
                            { lstPressRelease.RowHeight = 150; }
                            else if (Device.Idiom == TargetIdiom.Desktop)
                            { lstPressRelease.RowHeight = 3 * 100; }
                            else
                            { lstPressRelease.RowHeight = 150; }
                            #endregion
                            lstPressRelease.ItemsSource = PressReleaseList;
                            //   EventVisitLists.ItemsSource = EventGroupedList;
                            lstPressRelease.IsRefreshing = false;
                            // EventVisitLists.IsVisible = true;

                        }
                        else
                        {
                            if (index == 0)
                            {
                                lblNoRecord.IsVisible = true;
                                //   EventVisitLists.IsVisible = true;
                                PressReleaseList.Clear();
                                lstPressRelease.IsRefreshing = false;
                            }
                        }
                    }
                    else
                    {
                        if (App.CurrentPage() == "pressrelease")
                            await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
                    }

                }

                catch (WebException exception)
                {
                    if (App.CurrentPage() == "pressrelease")
                    {
                        if (exception.Message.Contains("Network"))
                            await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                    }
                }
            }
            loadingIndicator.IsVisible = false;
            loading.IsRunning = false;
            loading.IsVisible = false;
            lstPressRelease.IsRefreshing = false;
            FilterPressList.IsEnabled = true;
        }
        protected async override void OnAppearing()
        {
            if (Application.Current.Properties.ContainsKey("navigationflag"))
            {
                    if (!App.CheckInternetConnection())
                    {
                        loadingIndicator.IsVisible = false;
                        loading.IsRunning = false;
                        loading.IsVisible = false;
                        await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
                    }
                    else
                    {
                        index = 0;
                        loadingIndicator.IsVisible = true;
                        loading.IsRunning = true;
                        loading.IsVisible = true;
                        await CallWebServiceForPressRelease(index);
                    }
            }
            Application.Current.Properties["CurrentPage"] = "pressrelease";
        }
        public void TappressreleaseTitle(object sender, EventArgs args)
        {
            var pdflink = sender as WrappedTruncatedLabel;
            if((pdflink.ClassId != null) && (pdflink.ClassId !=""))
            Device.OpenUri(new Uri(pdflink.ClassId));
        }
        #region Exit Application
        private bool _canClose = true;

        protected override bool OnBackButtonPressed()
        {
            //if (_canClose)
            //{
            //    ShowExitDialog();
            //}
            //return _canClose;
            Application.Current.MainPage = new SideMenu();
            return true;
        }

        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert(AppResources.LExit, AppResources.LExitApp, AppResources.LYes, AppResources.LNo);
            if (answer)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    DependencyService.Get<IAndroidMethods>().CloseApp();
                }
                _canClose = false;
                OnBackButtonPressed();
            }
        }
        #endregion
    }
}
