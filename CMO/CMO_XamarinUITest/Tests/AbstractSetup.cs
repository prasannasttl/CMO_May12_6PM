using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CMO_UITest
{
	[TestFixture(Platform.Android)]
	//[TestFixture(Platform.iOS)]
	public abstract class AbstractSetup
	{
		protected IApp app;
		protected Platform platform;
		//readonly Query HamburgerMenuOpen;
		//readonly Query HamburgerMenuClose;

		protected AbstractSetup(Platform platform)
		{
			this.platform = platform;
			//HamburgerMenuOpen = x => x.Marked("Open navigation drawer");
			//HamburgerMenuClose = x => x.Marked("design_menu_item_text");
		}

		[SetUp]
		public virtual void BeforeEachTest()
		{
			if (app == null)
			{
				app = AppInitializer.StartApp(platform);
				Thread.Sleep(4000);
				app.WaitForNoElement("Loading data...");
				app.Screenshot("Application Home Page");
			}
			CheckInternetConnection();
		}

		/// <summary>
		/// Checks the internet connection.
		/// </summary>
		public void CheckInternetConnection()
		{
			try
			{
				string NoInternetMessage = "No Internet Connection available";
				string Ok = "button2";
				if (app.Query(NoInternetMessage).Any())
				{
					app.Screenshot("No Internet Connection in device");
					app.Tap(Ok);
					app.Screenshot("Internet Connection unavailable");
					Assert.Fail("No Internet Connection in device");
				}
			}
			catch (Exception ex)
			{
				app.Screenshot("Exception Error - CheckInternetConnection");
				Assert.Fail("Exception Error - CheckInternetConnection " + ex.Message);
			}
		}

		/// <summary>
		/// Errors the message display.
		/// </summary>
		/// <param name="message">Message.</param>
		public void ErrorMessageDisplay(string message)
		{
			try
			{
				if (message != string.Empty)
				{
					app.Screenshot(message);
					Assert.Fail(message);
				}
			}
			catch (Exception ex)
			{
				app.WaitForNoElement("Waiting for Error message");
				app.Screenshot("Exception Error - ErrorMessageDisplay");
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Finds the hamburger.
		/// </summary>
		//public void FindHamburger()
		//{
		//	try
		//	{
		//		while (!app.Query(HamburgerMenuOpen).Any())
		//		{
		//			app.Back();
		//		}

		//		if (app.Query(HamburgerMenuClose).Any())
		//		{
		//			app.Tap(HamburgerMenuClose);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		app.WaitForNoElement("Waiting for control");
		//		app.Screenshot("Exception Error - FindHamburger");
		//		Assert.Fail("Exception Error - FindHamburger " + ex.Message);
		//	}
		//}
	}
}