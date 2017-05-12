using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Foundation;
using SlideOverKit.iOS;
using UIKit;
using FFImageLoading.Forms.Touch;

namespace CMO.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
			/*var cv = typeof(Xamarin.Forms.CarouselView);
			var assembly = Assembly.Load(cv.FullName);*/
            CachedImageRenderer.Init();
            var b = UIScreen.MainScreen.Bounds;
            int h = (int)b.Height;
            int w = (int)b.Width;
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(20, 27, 61);
           // UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(244, 116, 33);
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.White
            });

            UIApplication.SharedApplication.SetStatusBarHidden(true, true);
			var mc = new MenuContainerPageiOSRenderer();
            CarouselView.FormsPlugin.iOS.CarouselViewRenderer.Init();
            LoadApplication(new App(w,h));
         //   LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
      
    }
}
