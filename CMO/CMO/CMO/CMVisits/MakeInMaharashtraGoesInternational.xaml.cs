using CMO.MenuController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Xamarin.Forms;
using System.Threading.Tasks;
using CMO.ServicesClasses;

namespace CMO.CMVisits
{
    public partial class MakeInMaharashtraGoesInternational : ContentPage
    {
        public string SearchFilterText = "";
        int widthdevice;
        int deviceheight;
        int index = 0;
        int totalItems = 0;
        int totalListItems = 0;
        decimal MaxIndex = 0;
        ObservableCollection<CmVisit> CountryList;
        public MakeInMaharashtraGoesInternational()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
           // index = 0;
            widthdevice = App.DeviceWidth;
            deviceheight = App.DeviceHeight;
			FilterMahrashtraVisitGoesInternationalList.FontSize = App.GetFontSizeMedium();
            if (TargetPlatform.Android == Device.OS)
            {
            //    EntryOuterStack.Padding = new Thickness(5, 7, 0, 0);
            }
            // firstrow.Height = (deviceheight * 6.5) / 100;
          
            this.Title = AppResources.LForeignVisits.ToUpper();
            GalleryList.ItemAppearing += GalleryList_ItemAppearing1;
            loadingIndicator.IsVisible = true;
            loading.IsRunning = true;
            loading.IsVisible = true;
            //GalleryList.IsVisible = false;
            GalleryList.ItemTapped += GalleryList_ItemTapped;
            GalleryList.Refreshing += GalleryList_Refreshing;
           // CallWebServiceForForiegnVisits(index);
        }
        private async void GalleryList_Refreshing(object sender, EventArgs e)
        {
            index = 0;
            loadingIndicator.IsVisible = false;
            loading.IsVisible = false;
            loading.IsRunning = false;
            if (lblNoRecord.IsVisible == true)
            {
                SearchFilterText = "";
                FilterMahrashtraVisitGoesInternationalList.Text = "";
            }
            lblNoRecord.IsVisible = false;
            await CallWebServiceForForiegnVisits(index);
        }
        private void GalleryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(MakeInMaharashtraGoesInternationalDetail))
            {
                var selectedMaharashtraListItem = sender as Xamarin.Forms.ListView;
                var objectt = selectedMaharashtraListItem.SelectedItem as CmVisit;
                if (objectt != null)
                {
                    Application.Current.Properties["navigationflag"] = "1";
                //    Navigation.PushAsync(new CMO.MakeInMaharashtraGoesInternationalDetail(objectt));
                }
            }
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
                    if (FilterMahrashtraVisitGoesInternationalList.Text == "" || FilterMahrashtraVisitGoesInternationalList.Text == null)
                    { SearchFilterText = ""; }
                    else
                    {
                        SearchFilterText = FilterMahrashtraVisitGoesInternationalList.Text;
                    }
                    index = 0;
                    loadingIndicator.IsVisible = true;
                    loading.IsRunning = true;
                    loading.IsVisible = true;
                   // GalleryList.IsVisible = false; u
                    CountryList.Clear();
                   await CallWebServiceForForiegnVisits(index);
                }
            }
        }
        private async void GalleryList_ItemAppearing1(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                if (totalItems != 0)
                {
                    MaxIndex = Math.Ceiling(((decimal)totalListItems) / 5);

                    if (index < MaxIndex)
                    {
                        if (CountryList != null && e.Item != null && e.Item == CountryList[CountryList.Count - 1])
                        {
                            index++;
                            if (index != MaxIndex)
                            {
                                loadingIndicator.IsVisible = true;
                                loading.IsVisible = true;
                                loading.IsRunning = true;
                               await CallWebServiceForForiegnVisits(index);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
				if (App.CurrentPage() == "makeinmaharashtrainternational")
				{
					if (ex.Message.Contains("Network"))
						await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
				}
            }
        }
        protected override async void OnAppearing()
        {

            //    index = 0;
            //if (Application.Current.Properties.ContainsKey("navigationflag"))
            //{
            //    var _currentPage = Application.Current.Properties["navigationflag"] as string;
            //    if (_currentPage == "1")
            //    {
            //        index = 0;
            //        loadingIndicator.IsVisible = true;
            //        loading.IsRunning = true;
            //        loading.IsVisible = true;
            //       // GalleryList.IsVisible = false; u
            //        CallWebServiceForForiegnVisits(index);
            //    }
            //}
            if (loading.IsRunning == true)
            {
               await CallWebServiceForForiegnVisits(index);
            }
            //    Application.Current.Properties["CurrentPage"] = "makeinmaharashtrainternational";
			lblNoRecord.FontSize = App.GetFontSizeMedium();

        }
        private async void LeftStackTaped(object sender, EventArgs e)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(MakeInMaharashtraGoesInternationalDetail))
            {
                var StackID = sender as Grid;
                if (StackID.ClassId != null)
                {
                  //  Application.Current.Properties["navigationflag"] = "";
                  // await Navigation.PushAsync(new CMO.MakeInMaharashtraGoesInternationalDetail(widthdevice, StackID.ClassId));
                }
            }
        }
		private async void RightStackTaped(object sender, EventArgs e)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(MakeInMaharashtraGoesInternationalDetail))
            {
                var StackID = sender as Grid;
                if (StackID.ClassId != null)
                {
                //    Application.Current.Properties["navigationflag"] = "2";
                //   await Navigation.PushAsync(new CMO.MakeInMaharashtraGoesInternationalDetail(widthdevice, StackID.ClassId));
                }
            }
        }
        public async Task CallWebServiceForForiegnVisits(int index)
        {
            if (!App.CheckInternetConnection())
            {
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            }
            else
            {
                try
                {
                    string lang = "";
                    if (Application.Current.Properties.ContainsKey("Language"))
                    { lang = Application.Current.Properties["Language"] as string; }

                    List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("lang", lang));
                    values.Add(new KeyValuePair<string, string>("title", SearchFilterText));
                    values.Add(new KeyValuePair<string, string>("country", ""));
                    values.Add(new KeyValuePair<string, string>("index", Convert.ToString(index)));
                    values.Add(new KeyValuePair<string, string>("limit", "8"));


                    var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectCMVisitList>("https://cmo.maharashtra.gov.in/api/cmforeignvisits", values);
                    if (response != null)
                    {
                        if (response._resultflag == 1)
                        {
                            totalItems = response.total_results;
                            totalListItems = response.search_results;
                            var x = GalleryList.RowHeight;
                            for (int i = 0; i < response.cm_visit.Count; i++)
                            {
                                DateTime oDate = Convert.ToDateTime(response.cm_visit[i].date);
                                response.cm_visit[i].date = oDate.ToString("MMM. dd, yyyy");
                            }
                            if (CountryList == null || index == 0)
                            {
                                CountryList = new ObservableCollection<CmVisit>();
                            }
                            for (int i = 0; i < response.cm_visit.Count; i++)
                            {
                                var ObjectCmVisitList = new CmVisit();
                                ObjectCmVisitList.SetFontSize = App.GetFontSizeMedium();
                                ObjectCmVisitList.date = response.cm_visit[i].date;
                                ObjectCmVisitList.image = response.cm_visit[i].image;
                                ObjectCmVisitList.ipad_thumb_path = response.cm_visit[i].ipad_thumb_path;
                                ObjectCmVisitList.twitter_link = response.cm_visit[i].twitter_link;
                                ObjectCmVisitList.title = response.cm_visit[i].title.ToUpper();
                                ObjectCmVisitList.description = response.cm_visit[i].description.Replace("<p>", "").Replace("</p>", "");
                                #region (Text) Specific Design implemention for phone and tablet
                                if (Device.Idiom == TargetIdiom.Phone)
                                {
                                    ObjectCmVisitList.TitleWidth = new GridLength(3, GridUnitType.Star);
                                    ObjectCmVisitList.ImageWidth = new GridLength(2, GridUnitType.Star);
                                    //	ObjectCmVisitList.TitleFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                                }
                                else if (Device.Idiom == TargetIdiom.Tablet)
                                {
                                    ObjectCmVisitList.TitleWidth = new GridLength(4, GridUnitType.Star);
                                    ObjectCmVisitList.ImageWidth = new GridLength(2, GridUnitType.Star);
                                    //     ObjectCmVisitList.TitleFontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                                }
                                else
                                {
                                    ObjectCmVisitList.TitleWidth = new GridLength(4, GridUnitType.Star);
                                    ObjectCmVisitList.ImageWidth = new GridLength(2, GridUnitType.Star);
                                    //  ObjectCmVisitList.TitleFontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                                }
                                #endregion

                                CountryList.Add(ObjectCmVisitList);
                            }
                            //if (JalyuktVisitLists.IsVisible == false)
                            //{
                            //    JalyuktVisitLists.IsVisible = true;
                            //}
                            #region (Row Height) Specific Design implemention for phone and tablet
                            if (Device.Idiom == TargetIdiom.Phone)
                            {
                                GalleryList.RowHeight = 100;
                            }
                            else if (Device.Idiom == TargetIdiom.Tablet)
                            {
                                GalleryList.RowHeight = 150;
                            }
                            else if (Device.Idiom == TargetIdiom.Desktop)
                            {
                                GalleryList.RowHeight = 3 * 100;
                            }
                            else
                            {
                                GalleryList.RowHeight = 150;
                            }
                            #endregion

                            GalleryList.ItemsSource = CountryList;
                            GalleryList.IsRefreshing = false;
                            // JalyuktVisitLists.IsVisible = true;
                        }
                        else
                        {
                            if (index == 0)
                            {
                                lblNoRecord.IsVisible = true;
                                CountryList.Clear();
                                // JalyuktVisitLists.IsVisible = false;
                                GalleryList.IsRefreshing = false;
                            }
                        }
                    }
                }
                catch (WebException exception)
                {
                    if (App.CurrentPage() == "makeinmaharashtrainternational")
                        await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                }
              //  GalleryList.IsVisible = true; u
                GalleryList.IsRefreshing = false;
            }
                loading.IsVisible = false;
                loading.IsRunning = false;
                loadingIndicator.IsVisible = false;
                GalleryList.IsRefreshing = false;

        }
        public async void TapMoreOnTwitter(object sender, EventArgs args)
        {
            var label = sender as Label;
            try
            {
                if (!App.CheckInternetConnection())
                {
                    await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
                }
                else
                {
                    Device.OpenUri(new Uri(label.ClassId));
                }
            }
            catch (Exception e)
            {
                await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
            }
        }


        //#region Exit Application
        //private bool _canClose = true;

        //protected override bool OnBackButtonPressed()
        //{
        //    //if (_canClose)
        //    //{
        //    //    ShowExitDialog();
        //    //}
        //    //return _canClose;
        //    Application.Current.MainPage = new SideMenu();
        //    return true;
        //}

        //private async void ShowExitDialog()
        //{
        //    var answer = await DisplayAlert(AppResources.LExit, AppResources.LExitApp, AppResources.LYes, AppResources.LNo);
        //    if (answer)
        //    {
        //        if (Device.OS == TargetPlatform.Android)
        //        {
        //            DependencyService.Get<IAndroidMethods>().CloseApp();
        //        }
        //        _canClose = false;
        //        OnBackButtonPressed();
        //    }
        //}
        //#endregion
    }

    public class DatalData
    {
        public string leftId { get; set; }
        public string leftimage { get; set; }
        public string lefttitle { get; set; }
        public string leftdate { get; set; }

        public string rightId { get; set; }
        public string rightimage { get; set; }
        public string righttitle { get; set; }
        public string rightdate { get; set; }

        public string CalenderIcon { get; set; }
        public Color ColorStackBorderleft { get; set; }
        public Color ColorStackBorderright { get; set; }
        public Color ColorStackBorderrightGrey {get; set;}
        public Color ImageBackgroundright { get; set; }
        public ImageSource PlaceholderRight { get; set; }
		public int SetFontSize { get; set; }
    }
}

