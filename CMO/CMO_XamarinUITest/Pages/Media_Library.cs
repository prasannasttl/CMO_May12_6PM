using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace CMO_UITest
{
	public class Media_Library : BasePage
	{
		public string ErrorMessage = string.Empty;
		readonly Query _menuBtn;
		readonly Query _medialib;
		readonly Query _okbtn;
		readonly Query _cancelbtn;

		readonly Query _newsUpdates;

		//Press Release page
		readonly Query _pressReleases;
		readonly Query _searchPressRelease;
		readonly Query _mnth;
		readonly Query _mnthSelector;
		readonly Query _year;


		readonly Query _photoGallery;
		readonly Query _searchPhoto;

		readonly Query _videoGallery;
		readonly Query _searchVideo;

		readonly Query _publicationGallery;
		readonly Query _menuscroll;
		readonly Query _eventsCalendar;

		public Media_Library(IApp app, Platform platform)
								: base(app, platform)
		{
			if (OnAndroid)
			{
				_menuBtn = x => x.Marked("Navigate up");
				_medialib = x => x.Marked("lbl_Gallery");
				_okbtn = x => x.Marked("button1");
				_cancelbtn = x => x.Marked("button2");
				_newsUpdates = x => x.Marked("lbl_NewsGallery");

				//Press Release page
				_pressReleases = x => x.Marked("lbl_PressClips");
				_searchPressRelease = x => x.Marked("FilterPressClip_Container");
				_mnth = x => x.Marked("MonthPicker_Container");
				_mnthSelector = x => x.Marked("custom");
				_year = x => x.Marked("YearPicker_Container");

				_photoGallery = x => x.Marked("lbl_PhotoGallery");
				_searchPhoto = x => x.Marked("FilterPhotoGallerytList");

				_videoGallery = x => x.Marked("lbl_VideoGallery");
				_searchVideo = x => x.Marked("FilterVideoGallerytList");

				_publicationGallery = x => x.Marked("lbl_MagazineGallery");
				_menuscroll = x => x.Marked("nav_scroll");
				_eventsCalendar = x => x.Marked("lbl_Events");
			}
		}

		public string NEWSUpdates()
		{
			try
			{
				//app.Repl();
				app.Tap(_menuBtn);
				app.WaitForElement(_medialib,"", TimeSpan.FromSeconds(5));
				app.Screenshot("Menu Openned or Navigation Drawer Openned");

				app.Tap(_medialib);
				app.WaitForElement(_newsUpdates, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Media library option tapped");

				app.Tap(_newsUpdates);
				app.WaitForElement(_menuBtn,"", TimeSpan.FromSeconds(5));
				app.Screenshot("News Updates page");



			}
			catch (Exception ex)
			{ 
				Assert.Fail("Error occur in NEWS Updates Page " + ex.Message); 
			}
			return ErrorMessage;
		}

		public string PressReleases()
		{
			try
			{
				
				app.Tap(_menuBtn);
				app.WaitForElement(_medialib, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Menu Openned or Navigation Drawer Openned");

				//app.Tap(_medialib);
				//app.WaitForElement(_pressReleases, "", TimeSpan.FromSeconds(5));
				//app.Screenshot("Media library option tapped");

				app.Tap(_pressReleases);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Press Releases page");
				//app.Repl();

				app.Tap(_mnth);
				app.WaitForElement(_mnthSelector, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Select Month");

				app.ScrollDown(_mnthSelector);
				app.WaitForElement(_okbtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("List of Months Scrolled Down");

				app.Tap(_okbtn);
				app.WaitForElement(_mnth, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Month Selection changed");

				app.Tap(_year);
				app.WaitForElement(_mnthSelector, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Select Year");

				app.ScrollUp(_mnthSelector);
				app.WaitForElement(_okbtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("List of Years Scrolled Up");

				app.Tap(_okbtn);
				app.WaitForElement(_year, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Year Selection Changed");

				app.Tap(_searchPressRelease);
				app.EnterText("A");
				app.WaitForElement(_searchPressRelease, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Text Entered in Search Bar");

			}
			catch (Exception ex)
			{ 
				Assert.Fail("Error occur in Press Releases Page " + ex.Message); 
			}
			return ErrorMessage;
		}

		public string PhotoGallery()
		{
			try
			{
				app.Tap(_menuBtn);
				app.WaitForElement(_medialib, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Menu Openned or Navigation Drawer Openned");

				//app.Tap(_medialib);
				//app.WaitForElement(_photoGallery, "", TimeSpan.FromSeconds(5));
				//app.Screenshot("Media library option tapped");

				app.Tap(_photoGallery);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Photo Gallery page");

				app.Tap(_searchPhoto);
				app.EnterText("A");
				app.WaitForElement(_searchPhoto, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Text Entered in Search Bar");
				
			}
			catch (Exception ex)
			{ 
				Assert.Fail("Error occur in Photo Gallery Page " + ex.Message); 
			}
			return ErrorMessage;
		}

		public string VideoGallery()
		{
			try
			{
				app.Tap(_menuBtn);
				app.WaitForElement(_medialib, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Menu Openned or Navigation Drawer Openned");

				//app.Tap(_medialib);
				//app.WaitForElement(_videoGallery, "", TimeSpan.FromSeconds(5));
				//app.Screenshot("Media library option tapped");

				app.Tap(_videoGallery);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Video Gallery  page");

				app.Tap(_searchVideo);
				app.EnterText("A");
				app.WaitForElement(_searchVideo, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Text Entered in Search Bar");

			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Video Gallery Page " + ex.Message);
			}
			return ErrorMessage;
		}

		public string PublicationGallery()
		{
			try
			{
				app.Tap(_menuBtn);
				app.WaitForElement(_medialib, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Menu Openned or Navigation Drawer Openned");

				//app.Tap(_medialib);
				//app.WaitForElement(_publicationGallery, "", TimeSpan.FromSeconds(5));
				//app.Screenshot("Media library option tapped");
				//app.Repl();

				app.Tap(_publicationGallery);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Publication Gallery page");

			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Publication Gallery Page " + ex.Message);
			}
			return ErrorMessage;
		}

		public string EventsCalendar()
		{
			try
			{
				app.Tap(_menuBtn);
				app.WaitForElement(_medialib, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Menu Openned or Navigation Drawer Openned");


				//app.ScrollDown(_menuscroll);
				//app.Screenshot("Navigation Drawer Openned");

				app.Tap(_eventsCalendar);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Events Calendar page");



			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Events Calendar Page " + ex.Message);
			}
			return ErrorMessage;
		}

	}
}
