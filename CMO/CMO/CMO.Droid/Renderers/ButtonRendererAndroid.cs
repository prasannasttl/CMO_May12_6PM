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
[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(ButtonRendererAndroid))]
namespace CMO.Droid.Renderers
{
    public class ButtonRendererAndroid : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                
                Element.FontSize = App.GetFontSizeSmall();
                Element.FontAttributes = FontAttributes.Bold;
				Element.BorderRadius = 0;
				if (Element != null)
				{
					if (!System.String.IsNullOrEmpty(Element.ClassId))
					{
						Control?.SetPadding(Control.PaddingLeft, 0, Control.PaddingRight, 0);
						Element.HeightRequest = App.GetFontSizeSmall() + 16;
					}
					else
					{
						//Element.HeightRequest = App.GetFontSizeSmall() + 16;
					}
				}
            }
        }
    }
}