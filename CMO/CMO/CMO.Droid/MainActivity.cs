using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Java.Util;
using Android.Util;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace CMO.Droid
{
    //[Activity(Theme = "@style/MyTheme" , Label = "CMO", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation , ScreenOrientation = ScreenOrientation.Portrait)]
    //public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    //{
    //    protected override void OnCreate(Bundle bundle)
    //    {
    //        base.OnCreate(bundle);
    //        var metrics = Resources.DisplayMetrics;
    //        int widthInDp = (int)(metrics.WidthPixels / metrics.Density);
    //        int heightInDp = (int)(metrics.HeightPixels / metrics.Density);


    //        global::Xamarin.Forms.Forms.Init(this, bundle);
    //        //var language = Android.App.Application.Context.Resources.Configuration.Locale.Language
    //        LoadApplication(new App(widthInDp, heightInDp));
    //    }

    //void ChangeLanguage(string cultureName)
    //{
    //    //var locale = new Java.Util.Locale(cultureName);
    //    //Java.Util.Locale.Default = locale;

    //    //var config = new Android.Content.Res.Configuration { Locale = locale };
    //    //BaseContext.Resources.UpdateConfiguration(config, BaseContext.Resources.DisplayMetrics);
    //    //var intent1 = new Intent(this, typeof(home_page));
    //    //StartActivity(intent1);

    //    Configuration config = Android.App.Application.Context.Resources.Configuration;
    //    var locale = new Locale(cultureName);
    //    config.SetLocale(locale);
    //    return Android.App.Application.Context.Resources.Configuration.Locale.Language;
    //    Android.App.Application.Context.Resources.UpdateConfiguration(config, Android.App.Application.Context.Resources.DisplayMetrics);
    //    //SaveString(this.Application, "cultureName", cultureName);
    //    //selectrdbtn = GetString(this.Application, "selectedradiobtn");
    //}
    // }

    [Activity(Label = "CMO", 
	          Theme = "@style/MyTheme",
	          Icon = "@drawable/icon",
	          ScreenOrientation = ScreenOrientation.Portrait, 
	          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity

	{
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

			#region Android Theme Changes
			// Set ActionBar app icon
			this.ActionBar.SetIcon(Android.Resource.Color.Transparent);
			//Set Actionbar title color
			TitleColor = Color.White;
			//Window window = this.Window;

			// clear FLAG_TRANSLUCENT_STATUS flag:
			//window.ClearFlags(WindowManagerFlags.TranslucentStatus);

			// add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
			//window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

			// Set Notification Bar/Status Bar Background color (#323E5E)
			//window.SetStatusBarColor(Color.Rgb(50, 62, 94));

		    #endregion

			var metrics = Resources.DisplayMetrics;
            int widthInDp = (int)(metrics.WidthPixels / metrics.Density);
            int heightInDp = (int)(metrics.HeightPixels / metrics.Density);

            /*DisplayMetrics displaymetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(displaymetrics);
            int height = displaymetrics.HeightPixels;
            int width = displaymetrics.WidthPixels;*/
            CarouselView.FormsPlugin.Android.CarouselViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(widthInDp, heightInDp));
        }
    }
}

