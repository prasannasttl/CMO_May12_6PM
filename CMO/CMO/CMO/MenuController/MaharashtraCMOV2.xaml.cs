using SlideOverKit;
using SlideOverKit.MoreSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.MenuController
{
    public partial class MaharashtraCMOV2 : MenuContainerPage
    {
        public MaharashtraCMOV2()
        {
            InitializeComponent();
            //BannerButton.FontSize = App.GetFontSizeTitle();
            this.SlideMenu = new RightSideMasterPageBottom();
        }
        #region Exit Application
        private bool _canClose = true;

        protected override bool OnBackButtonPressed()
        {
            if (this.SlideMenu.IsShown == true)
            {
                this.HideMenu();
            }
            else
            {
                if (_canClose)
                {
                    ShowExitDialog();
                }
            }
            return _canClose;
        }

        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert(AppResources.LExit, AppResources.LExitApp, AppResources.LYes, AppResources.LNo);
            if (answer)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    DependencyService.Get<IAndroidMethods>().CloseApp();
                }
                _canClose = false;
                OnBackButtonPressed();
            }
        }
        #endregion
        protected override void OnAppearing()
        {
            Application.Current.Properties["CurrentPage"] = "mahaapps";

        }
        public void CMOfficeTap(object sender, EventArgs args)
        {
            Application.Current.MainPage = new SideMenu();
        }

    }


}
