using CMO.iOS.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CMO.MenuController;

[assembly: ExportRenderer(typeof(ThreeLineLabel), typeof(ThreeLineLabelRendererIos))]
namespace CMO.iOS.Renderer
{
    public class ThreeLineLabelRendererIos : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.LineBreakMode = UILineBreakMode.TailTruncation;
                Control.Lines = 3;
            }
        }
    }
}

