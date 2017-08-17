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
	public class MainPage : BasePage
	{
		public string ErrorMessage = string.Empty;
		readonly Query _CMOffice;
		readonly Query _MenuBtn;
		readonly Query _CMInAction;
		readonly Query _TeamMaharastra;
		readonly Query _backHeader;
		readonly Query _Initiatives;
		readonly Query _JoinUs;
		readonly Query _NewsUpdates;
		readonly Query _NewsBtn;
		readonly Query _PhotoBtn;
		readonly Query _PhotoSlider;
		readonly Query _VideoBtn;
		readonly Query _VideoSlider;


		public MainPage(IApp app, Platform platform)
								: base(app, platform)
		{
			if (OnAndroid)
			{
				_CMOffice = x => x.Marked("ABannerButton_Container");
				_MenuBtn = x => x.Marked("Navigate up");
				_CMInAction = x => x.Marked("AlblCMVISIT_Container");
				_TeamMaharastra = x => x.Marked("AlblTEAMMAHARSHTRA_Container");
				_backHeader = x => x.Marked("Navigate up");
				_Initiatives = x => x.Marked("AlblINITIATIVES_Container");
				_JoinUs = x => x.Marked("AlblJOINUS_Container");
				_NewsUpdates = x => x.Marked("AlblNEWS_Container");
				_NewsBtn = x => x.Marked("AbtnNEWS");
				_PhotoBtn = x => x.Marked("AlblPHOTO");
				_PhotoSlider = x => x.Marked("APhotosListScroll");
				_VideoBtn = x => x.Marked("AbtnVIDEO");
				_VideoSlider = x => x.Marked("ANewsListScroll");

			}

		}

		public string Main()
		{
			try
			{
				//app.Repl();
				//Tap CM Office Button
				app.Tap(_CMOffice);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("CM Office Button Selected");

				app.Screenshot("Home Page");
				app.ScrollDown();
				app.WaitForElement(_PhotoBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Home Page Scroll Down");

				//swipe Photo gallery
				app.SwipeRightToLeft(_PhotoSlider);
				//swipe Video gallery
				app.SwipeRightToLeft(_VideoSlider);

				app.ScrollUp();
				app.WaitForElement(_CMInAction, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Home Page Scroll Up");

				app.Tap(_MenuBtn);
				app.Screenshot("Top Menu tapped or navigation menu oppened");

				app.Tap(_MenuBtn);
				app.Screenshot("Top Menu tapped or navigation menu Closed");

			//	app.Repl();

			}
			catch (Exception ex) { Assert.Fail("Error occur on Main Application Home  Page " + ex.Message); }
			return ErrorMessage;
		}

	}
}
