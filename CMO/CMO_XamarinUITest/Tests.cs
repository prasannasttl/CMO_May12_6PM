/*using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CMO_UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

		[SetUp][Ignore]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

		[Test][Ignore]
        public void AppLaunches() 
        {
            app.Screenshot("First screen.");
        }
    }
}
*/