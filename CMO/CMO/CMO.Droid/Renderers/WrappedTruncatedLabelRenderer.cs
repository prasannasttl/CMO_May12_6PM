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
using CMO.Gallery;
using CMO.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WrappedTruncatedLabel), typeof(WrappedTruncatedLabelRenderer))]
namespace CMO.Droid.Renderers
{
    public class WrappedTruncatedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.LayoutChange += (s, args) =>
                {
                    Control.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        Control.SetMaxLines(1);
                    }
                    else
                    {
                        Control.SetMaxLines(2);
                    }
                   
                   // Control.SetMaxLines((int)((args.Bottom - args.Top) / Control.LineHeight));
                };
            }
        }
    }
}