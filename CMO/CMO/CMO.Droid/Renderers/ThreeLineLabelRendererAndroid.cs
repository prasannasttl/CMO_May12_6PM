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
using Xamarin.Forms;
using CMO.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using CMO.MenuController;

[assembly: ExportRenderer(typeof(ThreeLineLabel), typeof(ThreeLineLabelRendererAndroid))]
namespace CMO.Droid.Renderers
{
    public class ThreeLineLabelRendererAndroid : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
				Control.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
               /* Control.LayoutChange += (s, args) =>
                {
                    Control.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
                    //Control.SetMaxLines(3);
                    Control.SetMaxLines((int)((args.Bottom - args.Top) / Control.LineHeight));
                };*/
            }
        }
    }
}