using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CMO.iOS.Renderer;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonRendererIos))]
namespace CMO.iOS.Renderer
{
    public class ButtonRendererIos : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                Element.FontSize = App.GetFontSizeSmall();
                Element.FontAttributes = FontAttributes.Bold;
				Element.BorderRadius = 0;
				if (Element != null)
				{
					if (Device.Idiom == TargetIdiom.Phone)
					{
						if (!System.String.IsNullOrEmpty(Element.ClassId))
						{
							Element.HeightRequest = App.GetFontSizeSmall() + 12;
						}
						else
						{
							Element.HeightRequest = App.GetFontSizeSmall() + 16;
						}
					}
				}
            }

        }
    }
}