using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CMO_UITest
{
    public static class AppInitializer
    {
        const string apiKey = "YOUR_API_KEY";
        //const string apkPath = "../../../XamarinCRM.Android/bin/Release/com.xamarin.xamarincrm-Signed.apk";
        //const string apkPath = "AutoGas_29_12_2015.apk";
        const string apkPath = "CMOTest.apk";
        //const string appFile = "../../../XamarinCRM.iOS/bin/iPhoneSimulator/Debug/XamarinCRMiOS.app";
        const string appFile = "CMOTest.ios.ipa";
        //const string bundleId = "com.xamarin.xamarinautogas"
        const string bundleId = "com.MahaCMO";


        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
					.Android.EnableLocalScreenshots()
                .StartApp();
            }
            return ConfigureApp
                    .iOS
                    .StartApp();

        }
    }
}