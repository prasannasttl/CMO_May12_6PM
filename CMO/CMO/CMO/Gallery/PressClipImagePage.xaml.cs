using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.Gallery
{
    public partial class PressClipImagePage : ContentPage
    {
        public PressClipImagePage(string img_url)
        {
            InitializeComponent();
            this.Title = AppResources.LpressReleaseDetail;
            PressReleaseImageZoomable.Source = img_url;
        }
    }
}
