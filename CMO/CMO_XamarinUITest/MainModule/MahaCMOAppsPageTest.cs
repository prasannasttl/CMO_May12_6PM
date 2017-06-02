using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace CMO_UITest.MainModule
{
	[TestFixture(Xamarin.UITest.Platform.Android)]
	//[TestFixture(Platform.iOS)]
	public class MahaCMOAppsPageTest
	{
		IApp app;
		Platform platform;
		public MahaCMOAppsPageTest(Platform platform)
		{
			this.platform = platform;
			//app = AppInitializer.StartApp(platform);
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		/*[Test]
		public void MaharashtraCMO_AppsPage()
		{
			Test1_NavigateToHomeScreen();
            Test2_AppListCarousel();
			Test3_TestAppListCarouselIndicators();
			Test4_OpenAppstoreOrApp();
		}
*/
		[Test]
		public void Test1_NavigateToHomeScreen()
		{
			app.Screenshot("On the Maharashtra CMO Applications Page");
			app.WaitForElement(c => c.Marked("AMahaGovAppsLabel").Text("MAHARASHTRA GOVERNMENT APPS"));
			app.Tap(c => c.Button("ABannerButton").Text("  CHIEF MINISTER OFFICE >  "));
			System.Threading.Thread.Sleep(4000);
			app.Screenshot("On CM Office Button Tap");
			app.Back();
		}

		[Test]
		public void Test2_AppListCarousel()
		{ 
			app.SwipeRightToLeft(c => c.Marked("ANewsCarouselView"));
			app.Screenshot("1 Swipe to left Maharashtra Apps List ");
			app.SwipeRightToLeft(c => c.Marked("ANewsCarouselView"));
			app.Screenshot("2 Swipe to left Maharashtra Apps List ");
			app.SwipeRightToLeft(c => c.Marked("ANewsCarouselView"));
			app.Screenshot("3 Swipe to left Maharashtra Apps List ");
		}


		[Test]
		public void Test3_TestAppListCarouselIndicators()
		{
			
			app.Tap(c => c.Marked("Unselected3"));
			app.WaitForElement(c => c.Marked("AItm1_Name"));
			app.WaitForElement(c => c.Marked("AItm1_Icon"));
			app.Screenshot("Tap Fourth Item of Maha Apps List ");

			app.Tap(c => c.Marked("Unselected1"));
			app.WaitForElement(c => c.Marked("AItm1_Name"));
			app.WaitForElement(c => c.Marked("AItm1_Icon"));
			app.Screenshot("Tap Second Item of Maha Apps List ");

			app.Tap(c => c.Marked("Unselected2"));
			app.WaitForElement(c => c.Marked("AItm1_Name"));
			app.WaitForElement(c => c.Marked("AItm1_Icon"));
			app.Screenshot("Tap Third Item of Maha Apps List ");

			app.Tap(c => c.Marked("Unselected0"));
			app.WaitForElement(c => c.Marked("AItm1_Name"));
			app.WaitForElement(c => c.Marked("AItm1_Icon"));
			app.Screenshot("Tap First Item of Maha Apps List ");

		} 

		[Test]
		public void Test4_OpenAppstoreOrApp()
		{
			
			try
			{
				app.WaitForElement(c => c.Marked("AItm2_TickMarkIcon"));
				// if TickMark icon visible Should navigate to app.
				app.Tap(c => c.Marked("AItm2_Icon"));
				//app.Screenshot("Tap Maharashtra Installed App opened ");
			}
			catch (Exception e)
			{
				// if TickMark not icon visible Should navigate to appstore.
				app.Tap(c => c.Marked("AItm2_Icon"));
				//app.Screenshot("Tap Maharashtra Installed App opened in play store");
			}
		}

	}
}