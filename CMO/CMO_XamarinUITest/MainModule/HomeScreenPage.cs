using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace CMO_UITest
{
	[TestFixture(Xamarin.UITest.Platform.Android)]
	//[TestFixture(Xamarin.UITest.Platform.iOS)]
	public class HomeScreenPage
	{
		IApp app;
		Platform platform;
		public HomeScreenPage(Platform platform)
		{
			this.platform = platform;
			//app = AppInitializer.StartApp(platform);
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void Test5_NavigateToHomeScreen()
		{
			app.Repl();
			app.Tap(c => c.Button("ABannerButton").Text("  CHIEF MINISTER OFFICE >  "));
			app.WaitForElement(c=> c.Text("HOME"));

			TapAlltheButtonsWhenServiceCalled();

			CheckNewsListServiceCalled();
			app.Repl();
		}

		public void TapAlltheButtonsWhenServiceCalled()
		{
			app.Tap(c => c.Button("AbtnNEWS"));
			app.ScrollDownTo( c => c.Button("AbtnVIDEO"));
			app.Tap(c => c.Button("AbtnVIDEO"));
			app.Tap(c => c.Button("AbtnPHOTO"));
		}

		public void CheckNewsListServiceCalled()
		{
			
		}

}
}