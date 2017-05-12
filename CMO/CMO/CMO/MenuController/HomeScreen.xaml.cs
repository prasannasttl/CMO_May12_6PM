using CMO.Gallery;
using CMO.ServicesClasses;
using SlideOverKit;
using SlideOverKit.MoreSample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.MenuController
{
	public partial class HomeScreen : MenuContainerPage, INotifyPropertyChanged
	{
		public bool currentpageFlag = true;
		public HomeScreen()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			FontSizeALL();
			if (Device.Idiom == TargetIdiom.Phone)
			{ NewsCarouselView.HeightRequest = 150; NewsCarouselViewGrid.HeightRequest = 150; }
			else
			{ NewsCarouselView.HeightRequest = 300; NewsCarouselViewGrid.HeightRequest = 300; }

			//bottomup.Clicked += Filterbutton_Clicked;
			//this.SlideMenu = new RightSideMasterPage();
		}
		public void slidertimer()
		{
			if (currentpageFlag == true)
			{
				if (NEWSLIST != null)
				{
					Position = 0;
					Device.StartTimer(TimeSpan.FromSeconds(5), () =>
					{
						if (Position >= 3)
						{
							//NewsList = null;
							//NewsCarouselView.ItemsSource = null;
							//NewsCarouselView.ItemsSource = NewsList ;
							NewsCarouselView.AnimateTransition = false;
							Position = 0;
						}
						else 						{ 							NewsCarouselView.AnimateTransition = true; 							Position++; 						}

						return true;
					});
				}
			}
		}
		public void FontSizeALL()
		{
			LblPhoto1.FontSize = App.GetFontSizeSmall();
			LblPhoto2.FontSize = App.GetFontSizeSmall();
			LblPhoto3.FontSize = App.GetFontSizeSmall();
			LblPhoto4.FontSize = App.GetFontSizeSmall();
			LblPhoto5.FontSize = App.GetFontSizeSmall();

			LblVideo1.FontSize = App.GetFontSizeSmall();
			LblVideo2.FontSize = App.GetFontSizeSmall();
			LblVideo3.FontSize = App.GetFontSizeSmall();
			LblVideo4.FontSize = App.GetFontSizeSmall();
			LblVideo5.FontSize = App.GetFontSizeSmall();

			lblNEWS.FontSize = App.GetFontSizeMedium();
			lblPHOTO.FontSize = App.GetFontSizeMedium();
			lblVIDEO.FontSize = App.GetFontSizeMedium();

			/* btnNEWS.FontSize = App.GetFontSizeSmall();
			 btnPHOTO.FontSize = App.GetFontSizeSmall();
			 btnVIDEO.FontSize = App.GetFontSizeSmall();*/

			lblCHIEFMINISTER.FontSize = App.GetFontSizeMedium();
			lblCMVISIT.FontSize = App.GetFontSizeMedium();
			lblTEAMMAHARSHTRA.FontSize = App.GetFontSizeMedium();
			lblINITIATIVES.FontSize = App.GetFontSizeMedium();
			lblJOINUS.FontSize = App.GetFontSizeMedium();
		}
		#region Binding Variables
		public static List<Newslist> NEWSLIST;
		public static List<GalleryList> PHOTOSLIST;
		public static List<Videolist> VIDEOSLIST;
		public List<Newslist> NewsList { get; set; } // Must have default value or be set before the BindingContext is set.
		private int _position;
		public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }
		public int _fontsizeheader { get; set; }
		public int FontSizeHeader { get { return _fontsizeheader; } set { _fontsizeheader = value; OnPropertyChanged(); } }
		public int _fontsizeGalleryLabels { get; set; }
		public int FontSizeGalleryLabels { get { return _fontsizeGalleryLabels; } set { _fontsizeGalleryLabels = value; OnPropertyChanged(); } }

		#endregion

		protected async override void OnAppearing()
		{
			Application.Current.Properties["CurrentPage"] = "home";

			if (!App.CheckInternetConnection())
			{
				await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
			}
			else
			{
				if (NEWSLIST == null)
					await CallWebServiceForNewsGalleryList();
				if (PHOTOSLIST == null)
					await CallWebServiceForPhotoGalleryList();
				if (VIDEOSLIST == null)
					await CallWebServiceForVideoGalleryList();
			}

			BindPhotos();
			BindVideos();
			BindNews();

			loadingPhotosList.IsEnabled = false; loadingPhotosList.IsVisible = false; loadingPhotosList.IsRunning = false;
			loadingVideosList.IsEnabled = false; loadingVideosList.IsVisible = false; loadingVideosList.IsRunning = false;
			loadingNewsList.IsEnabled = false; loadingNewsList.IsVisible = false; loadingNewsList.IsRunning = false;
			//   Mainloading.IsRunning = false; Mainloading.IsVisible = false; Mainloading.IsEnabled = false;
			slidertimer();
		}
		protected override void OnDisappearing()
		{
			currentpageFlag = false;
		}
		#region Webservice Calling
		public async Task CallWebServiceForNewsGalleryList()
		{
			loadingNewsList.IsEnabled = true; loadingNewsList.IsVisible = true; loadingNewsList.IsRunning = true;
			try
			{
				#region service parameters
				string lang = "";
				if (Application.Current.Properties.ContainsKey("Language"))
				{ lang = Application.Current.Properties["Language"] as string; }
				List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
				values.Add(new KeyValuePair<string, string>("lang", lang));
				values.Add(new KeyValuePair<string, string>("title", ""));
				values.Add(new KeyValuePair<string, string>("index", "0"));
				values.Add(new KeyValuePair<string, string>("limit", "4"));
				#endregion
				var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectNewsGalleryList>(CMO.ServiceLayer.ServiceLinks.NewUpdates_ListURL, values);
				if (response != null)
				{
					if (response._resultflag == 1)
					{
						NEWSLIST = new List<Newslist>();
						for (int i = 0; i < response.newslist.Count; i++)
						{
							var ObjectNewslist = new Newslist();
							ObjectNewslist.SetFontSize = App.GetFontSizeMedium();
							ObjectNewslist.SetFontSizeSmall = App.GetFontSizeSmall();
							ObjectNewslist.title = response.newslist[i].title;
							ObjectNewslist.page_id = response.newslist[i].page_id;
							ObjectNewslist.date = response.newslist[i].date;
							if (Device.Idiom == TargetIdiom.Phone)
								ObjectNewslist.thumb_img = response.newslist[i].thumb_img;
							else
								ObjectNewslist.thumb_img = response.newslist[i].ipad_thumb_path;
							ObjectNewslist.news_photo = response.newslist[i].news_photo;
							ObjectNewslist.content = response.newslist[i].content.Replace("<p>", "").Replace("</p>", "").Replace("&amp;", "&");
							NEWSLIST.Add(ObjectNewslist);
						}
					}
					else
					{
						await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
					}
				}
				else
				{
					await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
				}
			}
			catch (WebException exception)
			{
				if (exception.Message.Contains("Network"))
					await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
			}
		}
		public async Task CallWebServiceForPhotoGalleryList()
		{
			loadingPhotosList.IsEnabled = true; loadingPhotosList.IsVisible = true; loadingPhotosList.IsRunning = true;
			try
			{
				#region service parameters
				string lang = "";
				if (Application.Current.Properties.ContainsKey("Language"))
				{ lang = Application.Current.Properties["Language"] as string; }
				List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
				values.Add(new KeyValuePair<string, string>("lang", lang));
				values.Add(new KeyValuePair<string, string>("title", ""));
				values.Add(new KeyValuePair<string, string>("index", "0"));
				values.Add(new KeyValuePair<string, string>("limit", "5"));
				#endregion
				var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectPhotoGalleryList>(CMO.ServiceLayer.ServiceLinks.PhotoGallery_ListURL, values);
				if (response != null)
				{
					if (response._resultflag != 0)
					{
						PHOTOSLIST = new List<GalleryList>();
						PHOTOSLIST = response.gallery_list;
					}
				}
				else
				{
					await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
				}
			}
			catch (WebException exception)
			{
				if (exception.Message.Contains("Network"))
					await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
			}

		}
		public async Task CallWebServiceForVideoGalleryList()
		{
			loadingVideosList.IsEnabled = true; loadingVideosList.IsVisible = true; loadingVideosList.IsRunning = true;
			try
			{
				#region service parameters
				string lang = "";
				if (Application.Current.Properties.ContainsKey("Language"))
				{ lang = Application.Current.Properties["Language"] as string; }
				List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
				values.Add(new KeyValuePair<string, string>("lang", lang));
				values.Add(new KeyValuePair<string, string>("title", ""));
				values.Add(new KeyValuePair<string, string>("index", "0"));
				values.Add(new KeyValuePair<string, string>("limit", "5"));
				#endregion
				var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectVideoGalleryList>(CMO.ServiceLayer.ServiceLinks.VideoGallery_ListURL, values);
				if (response != null)
				{
					if (response._resultflag != 0)
					{
						VIDEOSLIST = new List<Videolist>();
						VIDEOSLIST = response.videolist;
					}
				}
				else
				{
					await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
				}
			}

			catch (WebException exception)
			{
				if (exception.Message.Contains("Network"))
					await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
			}
		}

		#endregion

		#region Module Tap Events
		public async void TapChiefMinisterImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(CMO.ChiefMinister.ChiefMinisterContentPage))
			{
				//   if (App.CheckInternetConnection())
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new CMO.ChiefMinister.ChiefMinisterContentPage("CM"));
			}
		}
		public async void TapCMVisitImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(CMO.ChiefMinister.ChiefMinisterContentPage))
			{
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new CMO.ChiefMinister.ChiefMinisterContentPage("CMV"));
			}
		}
		public async void TapTeamMaharashtraImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(CMO.ChiefMinister.ChiefMinisterContentPage))
			{
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new CMO.ChiefMinister.ChiefMinisterContentPage("TM"));
			}
		}
		public async void TapPhotoGalleryImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(Gallery.PhotoGalleryListPage))
			{
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new Gallery.PhotoGalleryListPage());
			}
		}
		public async void TapVideoGalleryImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(Gallery.VideoGallery))
			{
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new Gallery.VideoGallery());
			}
		}
		public async void TapNewsUpdatesImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(CMO.Gallery.NewsGalleryListPage))
			{
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new CMO.Gallery.NewsGalleryListPage());
			}
		}
		public async void TapInitiativesImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(CMO.ChiefMinister.ChiefMinisterContentPage))
			{
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new CMO.ChiefMinister.ChiefMinisterContentPage("Initiative"));
			}
		}
		public async void TapJoinUsImage(object sender, EventArgs args)
		{
			if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != typeof(CMO.ChiefMinister.ChiefMinisterContentPage))
			{
				Application.Current.Properties["navigationflag"] = "0";
				await Navigation.PushAsync(new CMO.ChiefMinister.ChiefMinisterContentPage("JU"));
			}
		}
		public void Filterbutton_Clicked(object sender, EventArgs e)
		{
			if (App.CheckInternetConnection())
			{
				var x = this.SlideMenu.IsFocused;
				if (this.SlideMenu.IsShown == false)
				{
					this.ShowMenu();
					RightSideMasterPage.ItemsAPPCLick = this.SlideMenu.IsShown;
				}
				else
				{
					this.HideMenu();
					RightSideMasterPage.ItemsAPPCLick = this.SlideMenu.IsShown;
				}
			}
		}
		#endregion
		#region Gallery tap Events
		#region Photo Gallery Tap Events
		public async void TapGridPhoto1(object sender, EventArgs args)
		{
			if (App.CheckInternetConnection() && (LblPhoto1.ClassId != null) && (LblPhoto1.ClassId != ""))
			{
				if (Device.Idiom == TargetIdiom.Phone)
					await Navigation.PushAsync(new PhotosListDetailPhone(LblPhoto1.ClassId));
				else
					await Navigation.PushAsync(new PhotosListDetail(LblPhoto1.ClassId));
			}
		}
		public async void TapGridPhoto2(object sender, EventArgs args)
		{
			if (App.CheckInternetConnection() && (LblPhoto2.ClassId != null) && (LblPhoto2.ClassId != ""))
			{
				if (Device.Idiom == TargetIdiom.Phone)
					await Navigation.PushAsync(new PhotosListDetailPhone(LblPhoto2.ClassId));
				else
					await Navigation.PushAsync(new PhotosListDetail(LblPhoto2.ClassId));
			}
		}
		public async void TapGridPhoto3(object sender, EventArgs args)
		{
			if (App.CheckInternetConnection() && (LblPhoto3.ClassId != null) && (LblPhoto3.ClassId != ""))
			{
				if (Device.Idiom == TargetIdiom.Phone)
					await Navigation.PushAsync(new PhotosListDetailPhone(LblPhoto3.ClassId));
				else
					await Navigation.PushAsync(new PhotosListDetail(LblPhoto3.ClassId));
			}
		}
		public async void TapGridPhoto4(object sender, EventArgs args)
		{
			if (App.CheckInternetConnection() && (LblPhoto4.ClassId != null) && (LblPhoto4.ClassId != ""))
			{
				if (Device.Idiom == TargetIdiom.Phone)
					await Navigation.PushAsync(new PhotosListDetailPhone(LblPhoto4.ClassId));
				else
					await Navigation.PushAsync(new PhotosListDetail(LblPhoto4.ClassId));
			}
		}
		public async void TapGridPhoto5(object sender, EventArgs args)
		{
			if (App.CheckInternetConnection() && (LblPhoto5.ClassId != null) && (LblPhoto5.ClassId != ""))
			{
				if (Device.Idiom == TargetIdiom.Phone)
					await Navigation.PushAsync(new PhotosListDetailPhone(LblPhoto5.ClassId));
				else
					await Navigation.PushAsync(new PhotosListDetail(LblPhoto5.ClassId));
			}
		}
		#endregion
		#region Video Gallery Tap Events
		public async void TapGridVideo1(object sender, EventArgs args)
		{ await openUrl(LblVideo1.ClassId); }
		public async void TapGridVideo2(object sender, EventArgs args)
		{ await openUrl(LblVideo2.ClassId); }
		public async void TapGridVideo3(object sender, EventArgs args)
		{ await openUrl(LblVideo3.ClassId); }
		public async void TapGridVideo4(object sender, EventArgs args)
		{ await openUrl(LblVideo4.ClassId); }
		public async void TapGridVideo5(object sender, EventArgs args)
		{ await openUrl(LblVideo5.ClassId); }
		public async Task openUrl(string url)
		{
			if (url != null && url != "")
			{
				var uri = new Uri(url);
				Device.OpenUri(uri);
			}
		}
		#endregion
		#endregion
		public void TapNewsUpdateItemGrid(object sender, EventArgs args)
		{
			if (NEWSLIST != null)
			{
				var newsitem = sender as Grid;
				var newsselecteditem = newsitem.BindingContext as Newslist;
				Navigation.PushAsync(new CMO.Gallery.NewsGalleryDetail(newsselecteditem));
			}
		}

		#region Binding data
		public void BindPhotos()
		{
			if (PHOTOSLIST != null)
			{
				ImgPhoto1.Source = null; ImgPhoto2.Source = null; ImgPhoto3.Source = null; ImgPhoto4.Source = null; ImgPhoto5.Source = null;
				LblPhoto1.Text = PHOTOSLIST[0].title;
				LblPhoto2.Text = PHOTOSLIST[1].title;
				LblPhoto3.Text = PHOTOSLIST[2].title;
				LblPhoto4.Text = PHOTOSLIST[3].title;
				LblPhoto5.Text = PHOTOSLIST[4].title;
				LblPhoto1.ClassId = PHOTOSLIST[0].page_id;
				LblPhoto2.ClassId = PHOTOSLIST[1].page_id;
				LblPhoto3.ClassId = PHOTOSLIST[2].page_id;
				LblPhoto4.ClassId = PHOTOSLIST[3].page_id;
				LblPhoto5.ClassId = PHOTOSLIST[4].page_id;
				if (Device.Idiom == TargetIdiom.Phone)
				{
					ImgPhoto1.Source = PHOTOSLIST[0].photo[0].thumb_path;
					ImgPhoto2.Source = PHOTOSLIST[1].photo[0].thumb_path;
					ImgPhoto3.Source = PHOTOSLIST[2].photo[0].thumb_path;
					ImgPhoto4.Source = PHOTOSLIST[3].photo[0].thumb_path;
					ImgPhoto5.Source = PHOTOSLIST[4].photo[0].thumb_path;
				}
				else
				{
					ImgPhoto1.Source = PHOTOSLIST[0].photo[0].ipad_thumb_path;
					ImgPhoto2.Source = PHOTOSLIST[1].photo[0].ipad_thumb_path;
					ImgPhoto3.Source = PHOTOSLIST[2].photo[0].ipad_thumb_path;
					ImgPhoto4.Source = PHOTOSLIST[3].photo[0].ipad_thumb_path;
					ImgPhoto5.Source = PHOTOSLIST[4].photo[0].ipad_thumb_path;
				}
			}
			loadingPhotosList.IsEnabled = false; loadingPhotosList.IsVisible = false; loadingPhotosList.IsRunning = false;
		}
		public void BindVideos()
		{
			if (VIDEOSLIST != null)
			{
				LblVideo1.Text = VIDEOSLIST[0].title;
				LblVideo2.Text = VIDEOSLIST[1].title;
				LblVideo3.Text = VIDEOSLIST[2].title;
				LblVideo4.Text = VIDEOSLIST[3].title;
				LblVideo5.Text = VIDEOSLIST[4].title;
				LblVideo1.ClassId = VIDEOSLIST[0].video_url;
				LblVideo2.ClassId = VIDEOSLIST[1].video_url;
				LblVideo3.ClassId = VIDEOSLIST[2].video_url;
				LblVideo4.ClassId = VIDEOSLIST[3].video_url;
				LblVideo5.ClassId = VIDEOSLIST[4].video_url;
				if (Device.Idiom == TargetIdiom.Phone)
				{
					ImgVideo1.Source = VIDEOSLIST[0].video_thumb_path;
					ImgVideo2.Source = VIDEOSLIST[1].video_thumb_path;
					ImgVideo3.Source = VIDEOSLIST[2].video_thumb_path;
					ImgVideo4.Source = VIDEOSLIST[3].video_thumb_path;
					ImgVideo5.Source = VIDEOSLIST[4].video_thumb_path;
				}
				else
				{
					ImgVideo1.Source = VIDEOSLIST[0].ipad_thumb_path;
					ImgVideo2.Source = VIDEOSLIST[1].ipad_thumb_path;
					ImgVideo3.Source = VIDEOSLIST[2].ipad_thumb_path;
					ImgVideo4.Source = VIDEOSLIST[3].ipad_thumb_path;
					ImgVideo5.Source = VIDEOSLIST[4].ipad_thumb_path;
				}
			}
			loadingVideosList.IsEnabled = false; loadingVideosList.IsVisible = false; loadingVideosList.IsRunning = false;
		}
		public void BindNews()
		{
			if (NEWSLIST != null)
			{
				NewsList = NEWSLIST;
				BindingContext = this;
			}
			loadingNewsList.IsEnabled = false; loadingNewsList.IsVisible = false; loadingNewsList.IsRunning = false;
		}

		#endregion
		#region Exit Application
		private bool _canClose = true;

		protected override bool OnBackButtonPressed()
		{
			//if (_canClose)
			//{
			//    ShowExitDialog();
			//}
			//return _canClose;
			Application.Current.MainPage = new NavigationPage(new CMO.MenuController.MaharashtraCMO());

			//Application.Current.MainPage = new SideMenu();
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

	public class CarouselData
	{
		public string Name { get; set; }
	}
	public class ThreeLineLabel : Label
	{ }
}
