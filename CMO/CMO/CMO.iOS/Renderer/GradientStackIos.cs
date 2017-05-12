using CMO.iOS.Renderer;
using CMO.MenuController;
using CoreAnimation;
using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(Gradient_Stack), typeof(GradientStackIos))]
namespace CMO.iOS.Renderer
{
    public class GradientStackIos : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            Gradient_Stack stack = (Gradient_Stack)this.Element;

            CGColor startColor = Color.Transparent.ToCGColor();
            CGColor endColor = Color.FromHex("#141b3d").ToCGColor();
            var gradientLayer = new CAGradientLayer()
            {
                //StartPoint = new CGPoint(0, 0.5),
                //EndPoint = new CGPoint(1, 0.5)
                StartPoint = new CGPoint(0.5, 0),
                EndPoint = new CGPoint(0.5, 1)
            };
            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor, endColor };
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}
