using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CMO.Droid.Renderers;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace CMO.Droid.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
            Control.TextAlignment = Android.Views.TextAlignment.Center;
            Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            Control.SetTextSize(Android.Util.ComplexUnitType.Dip,App.GetFontSizeMedium());
            Control.SetPadding(5, 0, 0, 0);
        }
    }
}
