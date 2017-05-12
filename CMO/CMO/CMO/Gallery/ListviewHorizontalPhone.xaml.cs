using CMO.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
namespace CMO.Gallery
{
    public partial class PhotosListDetailPhone : ContentPage
    {
        List<Photo> slidinglist = new List<Photo>();
        public string Photo_page_id = "";
        public PhotosListDetailPhone(string _photo_page_id)
        {
            InitializeComponent();
            this.Title = AppResources.LPhotos.ToUpper();
            NavigationPage.SetBackButtonTitle(this, "");
            LargeImage.HeightRequest = App.DeviceHeight * 0.40;
            Photo_page_id = _photo_page_id;
            //   LargeImage.WidthRequest = 600;

            xamllisthorizontal.ItemTapped += Xamllisthorizontal_ItemTapped;
        }
        protected async override void OnAppearing()
        {
            await CallWebServiceForPhotoGalleryList();
        }
        private void Xamllisthorizontal_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ListviewPhotoList = sender as ListView;
           // var selectedobject = ListviewPhotoList.SelectedItem as Photo;
            ListviewPhotoList.SelectedItem = null;
            //loading1.IsRunning = true; loading1.IsVisible = true;
            //Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            //{
            //    loading1.IsRunning = false; loading1.IsVisible = false;
            //    return false;
            //});
            //LargeImage.Source = selectedobject.photo_path;
            //LargeImageTitle.Text = selectedobject.photo_title;
        }
        #region Column Tap Events
        private void TapFirstImage(object sender, EventArgs e)
        {
            var PhotoObj = sender as Grid;
            var PhotoId = PhotoObj.BindingContext as ThreeImageRowClass;
            if (PhotoId != null)
            {
                if (PhotoId.FirstImageBigUrl != null)
                {
                    loading1.IsRunning = true; loading1.IsVisible = true;
                    LargeImage.Source = null;
                    loading1.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
					loading1.BindingContext = LargeImage;
                    LargeImage.Source = PhotoId.FirstImageBigUrl;
                    LargeImageTitle.Text = PhotoId.FirstImageTitle;
                }
            }
        }
        private void TapSecondImage(object sender, EventArgs e)
        {
            var PhotoObj = sender as Grid;
            var PhotoId = PhotoObj.BindingContext as ThreeImageRowClass;
            if (PhotoId != null)
            {
                if (PhotoId.SecondImageBigUrl != null)
                {
                    loading1.IsRunning = true; loading1.IsVisible = true;
                    LargeImage.Source = null;
                    loading1.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
					loading1.BindingContext = LargeImage;
                    LargeImage.Source = PhotoId.SecondImageBigUrl;
                    LargeImageTitle.Text = PhotoId.SecondImageTitle;
                }
            }
        }
        private void TapThirdImage(object sender, EventArgs e)
        {
            var PhotoObj = sender as Grid;
            var PhotoId = PhotoObj.BindingContext as ThreeImageRowClass;
            if (PhotoId != null)
            {
                if (PhotoId.ThirdImageBigUrl != null)
                {
                    loading1.IsRunning = true; loading1.IsVisible = true;
                    LargeImage.Source = null;
                    loading1.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
					loading1.BindingContext = LargeImage;
                    LargeImage.Source = PhotoId.ThirdImageBigUrl;
                    LargeImageTitle.Text = PhotoId.ThirdImageTitle;
                }
            }
        }
        #endregion
        public async Task CallWebServiceForPhotoGalleryList()
        {
            if (!App.CheckInternetConnection())
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            else
            {
                try
                {
                    string lang = "";
                    if (Application.Current.Properties.ContainsKey("Language"))
                    { lang = Application.Current.Properties["Language"] as string; }
                    List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("lang", lang));
                    values.Add(new KeyValuePair<string, string>("page_id", Photo_page_id));
                    var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectPhotoDetailResponse>(CMO.ServiceLayer.ServiceLinks.Photos_DetailURL, values);
                    if (response != null)
                    {
                        if (response._resultflag != 0)
                        {
                            foreach (var item in response.gallery_list.photo)
                                slidinglist.Add(item);
                            if (slidinglist != null)
                            {
                                LargeImage.Source = slidinglist[0].photo_path;
                                LargeImageTitle.Text = slidinglist[0].photo_title;
                                loading1.IsRunning = true; loading1.IsVisible = true;
                                if (slidinglist.Count > 1)
                                {
                                    BindIntoList(slidinglist);
                                    //xamllisthorizontal.ItemsSource = slidinglist;
                                    SlidingImageListLayout.IsVisible = true;
                                }
                                else
                                    SlidingImageListLayout.IsVisible = false;
                                GridLargeImage.IsVisible = true;
                                loading1.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
								loading1.BindingContext = LargeImage;
                            }

                        }
                    }
                    else
                    {
                        if (App.CurrentPage() == "photogallerylist")
                            await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
                    }
                }
                catch (WebException exception)
                {
                    if (App.CurrentPage() == "photogallerylist")
                    {
                        if (exception.Message.Contains("Network"))
                            await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                    }
                }
            }
            loading.IsRunning = false;
            loading.IsVisible = false;
        }
        public void BindIntoList(List<Photo> _photolist)
        {
            List<ThreeImageRowClass> ThreeImageRowList = new List<ThreeImageRowClass>();
            for (int i = 0; i < _photolist.Count; i++)
            {
                var objrow = new ThreeImageRowClass();
                #region Bind First Image
                objrow.FirstImageTitle = _photolist[i].photo_title;
                objrow.FirstImageBigUrl = _photolist[i].photo_path;
                objrow.FirstImageThumbUrl = _photolist[i].thumb_path;
                objrow.FirstPlaceholder = "photogalleryplaceholder";
                objrow.FistImageId = (i + 1).ToString();
                #endregion
                #region Bind Second Image
                i++;
                if (i < _photolist.Count)
                {
                    objrow.SecondImageTitle = _photolist[i].photo_title;
                    objrow.SecondImageBigUrl = _photolist[i].photo_path;
                    objrow.SecondImageThumbUrl = _photolist[i].thumb_path;
                    objrow.SecondPlaceholder = "photogalleryplaceholder";
                    objrow.SecondImageId = (i + 1).ToString();
                }
                else
                {
                    objrow.SecondImageTitle = null;
                    objrow.SecondImageBigUrl = null;
                    objrow.SecondImageThumbUrl = null;
                    objrow.SecondPlaceholder = null;
                    objrow.SecondImageId = null;
                }
                #endregion
                #region Bind Third Image
                i++;
                if (i < _photolist.Count)
                {
                    objrow.ThirdImageTitle = _photolist[i].photo_title;
                    objrow.ThirdImageBigUrl = _photolist[i].photo_path;
                    objrow.ThirdImageThumbUrl = _photolist[i].thumb_path;
                    objrow.ThirdPlaceholder = "photogalleryplaceholder";
                    objrow.ThirdImageId = (i + 1).ToString();
                }
                else
                {
                    objrow.ThirdImageTitle = null;
                    objrow.ThirdImageBigUrl = null;
                    objrow.ThirdImageThumbUrl = null;
                    objrow.ThirdPlaceholder = null;
                    objrow.ThirdImageId = null;
                }
                #endregion
                ThreeImageRowList.Add(objrow);
            }
            xamllisthorizontal.ItemsSource = ThreeImageRowList;
        }
    }
    public class ThreeImageRowClass
    {
        #region Images Id 
        public string FistImageId { get; set; }
        public string SecondImageId { get; set; }
        public string ThirdImageId { get; set; }
        #endregion
        #region Images Title
        public string FirstImageTitle { get; set; }
        public string SecondImageTitle { get; set; }
        public string ThirdImageTitle { get; set; }
        #endregion
        #region Images Url Thumb
        public string FirstImageThumbUrl { get; set; }
        public string SecondImageThumbUrl { get; set; }
        public string ThirdImageThumbUrl { get; set; }
        #endregion
        #region Images Url Big
        public string FirstImageBigUrl { get; set; }
        public string SecondImageBigUrl { get; set; }
        public string ThirdImageBigUrl { get; set; }
        #endregion
        #region Placeholder
        public string FirstPlaceholder { get; set; }
        public string SecondPlaceholder { get; set; }
        public string ThirdPlaceholder { get; set; }
        #endregion
    }
}
