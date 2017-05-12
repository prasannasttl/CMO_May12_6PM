using CMO.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CMO.Initiatives
{
    public partial class InitiativesContentMain : ContentPage
    {
        
        List<CmVisit> CountryList;
        public string CountryTitle = "";
        public InitiativesContentMain()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            setfontsize();
            Application.Current.Properties["CurrentPage"] = CMO.MenuController.SideMenu.InitiativesCurrentPageName;
        }
        protected async override void OnAppearing()
        {
            await CallWebServiceForForiegnVisits(CountryTitle);
        }
        public void setfontsize()
        {
            JalyuktaVisittitle.FontSize = App.GetFontSizeMedium();
            JalyuktaVisitDate.FontSize = App.GetFontSizeSmall();
            JalyuktaVisitDetail.FontSize = App.GetFontSizeSmall();
        }
        public async void TapPhotoImage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CMO.Gallery.PhotosListDetail(CountryList[0].photo_page_id));
        }
        public void TapMoreOnTwitter(object sender, EventArgs args)
        {
            openurl(CountryList[0].twitter_link);
        }
        public void TapVideoImage(object sender, EventArgs args)
        {
            openurl(CountryList[0].video_gallery_id);
        }
        private void openurl(string url)
        {
            var uri = new Uri(url);
            Device.OpenUri(uri);
        }
        public async Task CallWebServiceForForiegnVisits(string countrytitle)
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
                    #region key value data
                    List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("lang", lang));
                    values.Add(new KeyValuePair<string, string>("title", ""));
                    values.Add(new KeyValuePair<string, string>("page_id", "432"));
                    values.Add(new KeyValuePair<string, string>("country", ""));
                    values.Add(new KeyValuePair<string, string>("index", "0"));
                    values.Add(new KeyValuePair<string, string>("limit", "1"));
                    #endregion
                    var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectCMVisitList>("https://cmo.maharashtra.gov.in/api/cmforeignvisits", values);
                    if (response != null)
                    {
                        if (response._resultflag == 1)
                        {
                            CountryList = new List<CmVisit>();
                            for (int i = 0; i < response.cm_visit.Count; i++)
                            {
                                DateTime oDate = Convert.ToDateTime(response.cm_visit[i].date);
                                CountryList = new List<CmVisit>();
                                CountryList = response.cm_visit;
                                response.cm_visit[i].date = oDate.ToString("MMM. dd, yyyy");
                                Title = response.cm_visit[i].title.ToUpper();
                                JalyuktaDetailImage.Source = response.cm_visit[i].image;
                                JalyuktaVisittitle.Text = response.cm_visit[i].title;
                                JalyuktaVisitDate.Text = response.cm_visit[i].date;
                                JalyuktaVisitDetail.Text = response.cm_visit[i].description.Replace("<p>", "").Replace("</p>", "");
                                JalyuktaDetailImage.HeightRequest = App.DeviceHeight * 0.40;
                                JalyuktaDetailImageBackgrnd.HeightRequest = App.DeviceHeight * 0.40;
                                Mainstack1.IsVisible = true;
                                Mainstack2.IsVisible = true;
                                if ((CountryList[0].photo_page_id != "") && (CountryList[0].photo_page_id != null))
                                { PhotoGrid.IsVisible = true; PhotoGrid.IsEnabled = true; }
                                if ((CountryList[0].video_gallery_id != "") && (CountryList[0].video_gallery_id != null))
                                { VideoGrid.IsVisible = true; VideoGrid.IsEnabled = true; }
                                if ((CountryList[0].twitter_link != "") && (CountryList[0].twitter_link != null))
                                { TwitterGrid.IsVisible = true; TwitterGrid.IsEnabled = true; }
                            }
                        }
                    }
                }
                catch (WebException exception)
                {
                    await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                }
            }
            loading.IsVisible = false;
            loading.IsRunning = false;
        }
    }
}
