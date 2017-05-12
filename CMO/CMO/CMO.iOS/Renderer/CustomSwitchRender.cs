using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CMO.iOS.Renderer;

[assembly: ExportRenderer(typeof(Switch), typeof(CustomSwitchRender))]

namespace CMO.iOS.Renderer
{
    public class CustomSwitchRender : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UISwitch here!
              //  Control.OnTintColor = UIColor.FromRGB(244, 116, 33);// switch fill colorvacche ni khali jagya in that default color is 
              //  Control.ThumbTintColor = UIColor.FromRGB(244, 116, 33);// switch dot color
                Control.TintColor = UIColor.FromRGB(244, 116, 33);//switch border color
             //   Control.BackgroundColor = UIColor.Green;// switch background color
            
            }
        }
    }
}
