using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace CMO_UITest
{
	[TestFixture(Xamarin.UITest.Platform.Android)]
	//[TestFixture(Platform.iOS)]
	public class CallRepl
    {
		IApp app;
		Platform platform;
		public CallRepl(Platform platform)
		{
			this.platform = platform;
		}
		[SetUp][Ignore]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

		[Test][Ignore]
        public void DisplayScreenHierarchy()
        {
            app.Repl();
        }
		/*[Test]
		public void FirstPage()
		{
			var MahaAppsPage = new CMO_UITest.MainModule.MahaCMOAppsPageTest(app);
		}*/
    }
}