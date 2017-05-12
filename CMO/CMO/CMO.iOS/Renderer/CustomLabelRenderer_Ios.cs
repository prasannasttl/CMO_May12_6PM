using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CMO.iOS.Renderer;
using UIKit;
using CMO.Gallery;

[assembly: ExportRenderer(typeof(WrappedTruncatedLabel), typeof(CustomLabelRenderer_Ios))]
namespace CMO.iOS.Renderer
{
    public class CustomLabelRenderer_Ios : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
			//Control.Lines = 2;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				Control.Lines = 2;
			}
			else
			{
				Control.Lines = 1;
			}
		}
    }
}