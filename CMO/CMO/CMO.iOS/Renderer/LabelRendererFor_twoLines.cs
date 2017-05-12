using CMO.Gallery;
using CMO.iOS.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WrappedTruncatedLabelTwoLine), typeof(LabelRendererFor_twoLines))]
namespace CMO.iOS.Renderer
{
    public class LabelRendererFor_twoLines : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.LineBreakMode = UILineBreakMode.TailTruncation;
                Control.Lines = 2;
                if (Element != null)
                {
                    if (Element.ClassId != "RemoveBkg")
                        Control.BackgroundColor = UIColor.FromRGB(19, 37, 97);
                }
            }
        }
    }
}
