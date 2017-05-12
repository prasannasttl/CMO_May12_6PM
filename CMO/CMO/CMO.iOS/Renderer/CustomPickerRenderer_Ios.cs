using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CMO.iOS.Renderer;
using UIKit;
[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer_Ios))]


namespace CMO.iOS.Renderer
{
    public class CustomPickerRenderer_Ios : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            UIFont font;
            Control.BorderStyle = UITextBorderStyle.None;
            font = Control.Font.WithSize(App.GetFontSizeMedium());

            Control.Font = font;

        }
    }
}
