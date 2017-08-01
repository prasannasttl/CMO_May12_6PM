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

		readonly Query _newsUpdates;
		readonly Query _pressReleases;
		readonly Query _photoGallery;
		readonly Query _videoGallery;
		readonly Query _publicationGallery;
		readonly Query _menuscroll;
		readonly Query _eventsCalendar;

		public Media_Library(IApp app, Platform platform)
								: base(app, platform)
		{
			if (OnAndroid)
			{
				_menuBtn = x => x.Marked("Navigate up");
				_medialib = x => x.Marked("MEDIA LIBRARY");
				_newsUpdates = x => x.Marked("News Updates");
				_pressReleases = x => x.Marked("Press Releases");
				_photoGallery = x => x.Marked("Photo Gallery");
				_videoGallery = x => x.Marked("Video Gallery");
				_publicationGallery = x => x.Text("Publications Gallery");
				_menuscroll = x => x.Marked("nav_scroll");
				_eventsCalendar = x => x.Marked("Events Calendar");
			}
		}

		public string NEWSUpdates()
		{
			try
			{
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
				app.Repl();

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


				app.ScrollDown(_menuscroll);
				app.Screenshot("Navigation Drawer Openned");

				//app.Tap(_medialib);
				//app.WaitForElement(_eventsCalendar, "", TimeSpan.FromSeconds(5));
				//app.Screenshot("Media library option tapped");

				app.Tap(_eventsCalendar);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Events Calendar page");

				app.Tap(_menuBtn);
				app.Tap(_medialib);

			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Events Calendar Page " + ex.Message);
			}
			return ErrorMessage;
		}

	}
}
