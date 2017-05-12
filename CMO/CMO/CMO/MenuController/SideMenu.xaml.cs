using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.MenuController
{
    public partial class SideMenu : MasterDetailPage
    {
        public static string TeamMaharashtraPageID;
        public static string InitiativesCurrentPageName;
        #region tap Flags
        //bool HomeFlag = false;
        bool CMOfficeFlag = false;
        bool ChiefMinisterFlag = false;
        bool JoinUsFlag = false;
        bool CMVisitFlag = false;
        bool InitiativesFlag = false;
        bool TeamMaharashtraFlag = false;
        bool GalleryModuleFlag = false;
        //bool ChangeLanguageFLag = false;
        //bool ApplicationListFlag = false;
        #endregion
        public SideMenu()
        {
            InitializeComponent();
            string lang = "";
            if (Application.Current.Properties.ContainsKey("language"))
                lang = Application.Current.Properties["language"] as string;
            if (Device.OS == TargetPlatform.Android)
            {
                MenuStack.IsVisible = false;
                SubScrollStack.Padding = new Thickness(0, 7, 0, 10);
            }
            else
            {
                MenuStack.IsVisible = true;
                SubScrollStack.Padding = new Thickness(0, 0, 0, 10);
            }
            setfontsize();
            IsPresentedChanged += SideMenu_IsPresentedChanged;
            //this.Detail = new NavigationPage(new CMO.MenuController.HomeScreen());
        }
        public void setfontsize()
        {
            #region 0 for Headers
            HOMEHeader.FontSize = App.GetFontSizeTitle();
            CMOfficeHEADER.FontSize = App.GetFontSizeTitle();
            ChiefMinisterHEADER.FontSize = App.GetFontSizeTitle();
            InitiativesHEADER.FontSize = App.GetFontSizeTitle();
            TeamMaharashtrasHEADER.FontSize = App.GetFontSizeTitle();
            JoinUsHEADER.FontSize = App.GetFontSizeTitle();
            CMVisitHEADER.FontSize = App.GetFontSizeTitle();
            GalleryModuleHEADER.FontSize = App.GetFontSizeTitle();
            ChangeLanguageHEADERLABEL.FontSize = App.GetFontSizeTitle();
            #endregion

            #region 1 for  CMOffice module 
            ITEMTeamCMO.FontSize = App.GetFontSizeSmall();
            ITEMFormerCMs.FontSize = App.GetFontSizeSmall();
            ITEMContactCMO.FontSize = App.GetFontSizeSmall();
            #endregion

            #region 2 for  The Chief Minister module
            ITEMBiography.FontSize = App.GetFontSizeSmall();
            ITEMVissionMissionOath.FontSize = App.GetFontSizeSmall();
            ITEMPersonalWebsite.FontSize = App.GetFontSizeSmall();
            #endregion

            #region 3 for  Initiatives module 
            ITEMApleSarkar.FontSize = App.GetFontSizeSmall();
            ITEMDroughtFreeMaharashtra.FontSize = App.GetFontSizeSmall();
            ITEMSwatchMaharashtra.FontSize = App.GetFontSizeSmall();
            ITEMMakeInMaharashtra.FontSize = App.GetFontSizeSmall();
            ITEMSkillDevelopment.FontSize = App.GetFontSizeSmall();
            ITEMRightToService.FontSize = App.GetFontSizeSmall();
            ITEMDigitalMaharashtra.FontSize = App.GetFontSizeSmall();
            ITEMChiefMinistersAssistance.FontSize = App.GetFontSizeSmall();
            #endregion

            #region 4 for  TeamMaharashtra module 
            ITEMGoverner.FontSize = App.GetFontSizeSmall();
            ITEMCabinetMinister.FontSize = App.GetFontSizeSmall();
            ITEMStateMinister.FontSize = App.GetFontSizeSmall();
            ITEMChiefJustice.FontSize = App.GetFontSizeSmall();
            ITEMSecretaries.FontSize = App.GetFontSizeSmall();
            ITEMCollectors.FontSize = App.GetFontSizeSmall();
            ITEMGovtDepartment.FontSize = App.GetFontSizeSmall();
            #endregion

            #region 5 for  Join Us module 
            ITEMSocialResponsibilityCell.FontSize = App.GetFontSizeSmall();
            ITEMmCMsInternshipProgram.FontSize = App.GetFontSizeSmall();
            ITEMCMsReliefFund.FontSize = App.GetFontSizeSmall();
            ITEMMyGov.FontSize = App.GetFontSizeSmall();
            #endregion

            #region 6  for CMVisit module 
            ITEMMakeInMaharashtraGoesInternational.FontSize = App.GetFontSizeSmall();
            ITEMMaharashtraVisits.FontSize = App.GetFontSizeSmall();
            ITEMJalyuktaVisit.FontSize = App.GetFontSizeSmall();

            #endregion

            #region 7 for  Gallery module 
            ITEMNewsGallery.FontSize = App.GetFontSizeSmall();
            ITEMMagazineGallery.FontSize = App.GetFontSizeSmall();
            ITEMPhotoGallery.FontSize = App.GetFontSizeSmall();
            ITEMVideoGallery.FontSize = App.GetFontSizeSmall();
            ITEMPressReleases.FontSize = App.GetFontSizeSmall();
            ITEMEvents.FontSize = App.GetFontSizeSmall();
            ITEMPressClips.FontSize = App.GetFontSizeSmall();
            #endregion
        }
        private void SideMenu_IsPresentedChanged(object sender, EventArgs e)
        {
            MasterBehavior = Xamarin.Forms.MasterBehavior.Popover;
            if (App.CurrentPage() == "changelang")
            {
                if (IsPresented == true)
                {
                    ChangedTitle();
                }
            }
        }
        public void ChangedTitle()
        {
            #region Menu & Home
            MENUHeader.Text = AppResources.LMenu;
            HOMEHeader.Text = AppResources.LHome;
            #endregion
            #region CMOffice
            CMOfficeHEADER.Text = AppResources.LCmOffice;
            ITEMTeamCMO.Text = AppResources.LTeamcmo;
            ITEMFormerCMs.Text = AppResources.LFormercmo;
            ITEMContactCMO.Text = AppResources.LContactcmo;
            #endregion
            #region ChiefMinister
            ChiefMinisterHEADER.Text = AppResources.LTheChiefMinister;
            ITEMBiography.Text = AppResources.LBiography;
            ITEMVissionMissionOath.Text = AppResources.LVisionMissionOath;
            ITEMPersonalWebsite.Text = AppResources.LPersonalWebsite;
            #endregion
            #region Initiatives
            InitiativesHEADER.Text = AppResources.LInitiatives;
            ITEMApleSarkar.Text = AppResources.LAapleSarkar;
            ITEMDroughtFreeMaharashtra.Text = AppResources.LDroughtFreeMaharashtra;
            ITEMSwatchMaharashtra.Text = AppResources.LSwachhMaharashtra;
            ITEMMakeInMaharashtra.Text = AppResources.LMakeInMaharashtra;
            ITEMSkillDevelopment.Text = AppResources.LSkillDevelopment;
            ITEMRightToService.Text = AppResources.LRightToService;
            ITEMDigitalMaharashtra.Text = AppResources.LDigitalMaharashtra;
            ITEMChiefMinistersAssistance.Text = AppResources.LChiefMinistersAssistanceCell;
            #endregion
            #region TeamMaharashtras
            TeamMaharashtrasHEADER.Text = AppResources.LTeamMaharashtra;
            ITEMGoverner.Text = AppResources.LGovernor;
            ITEMCabinetMinister.Text = AppResources.LCabinetMinister;
            ITEMStateMinister.Text = AppResources.LStateMinisters;
            ITEMChiefJustice.Text = AppResources.LMenuChiefMinister;
            ITEMSecretaries.Text = AppResources.LSecretaries;
            ITEMCollectors.Text = AppResources.LCollectors;
            ITEMGovtDepartment.Text = AppResources.LGovtDepartment;
            #endregion
            #region CMVisit
            CMVisitHEADER.Text = AppResources.LCmVisits;
            ITEMMakeInMaharashtraGoesInternational.Text = AppResources.LForeignVisits;
            ITEMMaharashtraVisits.Text = AppResources.LMaharashtraVisits;
            ITEMJalyuktaVisit.Text = AppResources.LJalyuktaVisits;
            #endregion
            #region Gallery
            GalleryModuleHEADER.Text = AppResources.LGallery;
            ITEMNewsGallery.Text = AppResources.LNewsGallery;
            ITEMMagazineGallery.Text = AppResources.LMagazineGallery;
            ITEMPhotoGallery.Text = AppResources.LMenuPhotoGallery;
            ITEMVideoGallery.Text = AppResources.LMenuVideoGallery;
            ITEMPressReleases.Text = AppResources.LMenuPressRelease;
            ITEMEvents.Text = AppResources.LEvents;
            ITEMPressClips.Text = AppResources.LPressClip;
            #endregion
            #region JoinUs
            JoinUsHEADER.Text = AppResources.LJoinUs;
            ITEMSocialResponsibilityCell.Text = AppResources.LSocialResponsibilityCell;
            ITEMmCMsInternshipProgram.Text = AppResources.LCmInternshipProgram;
            ITEMCMsReliefFund.Text = AppResources.LCmReliefsFund;
            ITEMMyGov.Text = AppResources.LMyGov;
            #endregion
            #region Change Language
            ChangeLanguageHEADERLABEL.Text = AppResources.LChangeLanguage;
            #endregion
            #region Application List

            #endregion
            #region News Feed

            #endregion
        }
        #region Gallery methods
        private void ItemPressClipTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "pressclip")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Gallery.PressClips)));
            }
        }
        private void PressReleaseTapped_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "pressrelease")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.ComingSoonPage)));
            }

        }
        private void VideoGalleryTapped_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "videogallery")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Gallery.VideoGallery)));
            }
        }
        private void NewsGalleryTapped_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "newsgallerylist")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Gallery.NewsGalleryListPage)));
            }
        }
        private void PhotoGalleryTapped_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "photogallerylist")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Gallery.PhotoGalleryListPage)));
            }
        }
        private void MagazineTapped_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "magazinegallery")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Gallery.MagazineGallery)));
            }
        }
        private void ItemEventsTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "events")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMVisits.Eventslists)));
            }
        }
        #endregion
        #region Chief Minister Methods
        private void VisionMissionOathTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "vision")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.ChiefMinister.VisionMissionOath)));
            }
        }
        private void PersonalWebsiteTap_Tapped(object sender, EventArgs e)
        {
            var uri = new Uri("http://www.devendrafadnavis.in/index.html");
            //    Device.OpenUri(new Uri("mailto:ryan.hatfield@test.com"));
            Device.OpenUri(uri);
        }
        private void Biographytap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "biography")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.ChiefMinister.Biography)));
            }
        }
        #endregion
        #region Initiatives Methods
        private void ChiefMinisterAssistanceTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "cmmasRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }
        private void DigitalMaharashtraTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "digitalRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }
        private void RightToServiceTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "righttoservRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }
        private void SkillDevelopmentTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "skilldevRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }
        private void MakeInMaharashtraTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "makeinRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }
        private void SwatchMaharashtraTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "swachhRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }
        private void DroughtFreeMaharashtraTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "droughtfreeRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }
        private void ApleSarkarTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            InitiativesCurrentPageName = "aapleSarkarRow";
            if (App.CurrentPage() != InitiativesCurrentPageName)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.Initiatives.InitiativesMain)));
            }
        }

        #endregion
        #region TeamMaharashra methods
        private void ItemGovtDeptTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            TeamMaharashtraPageID = "47";
            if (App.CurrentPage() != TeamMaharashtraPageID)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra)));
            }
        }
        private void ItemCollectorsTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            TeamMaharashtraPageID = "45";
            if (App.CurrentPage() != TeamMaharashtraPageID)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra)));
            }
        }
        private void ItemSecretariesTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            TeamMaharashtraPageID = "44";
            if (App.CurrentPage() != TeamMaharashtraPageID)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra)));
            }
        }
        private void ItemChiefJusticeTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            TeamMaharashtraPageID = "43";
            if (App.CurrentPage() != TeamMaharashtraPageID)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra)));
            }
        }
        private void ItemStateMinisterTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            TeamMaharashtraPageID = "42";
            if (App.CurrentPage() != TeamMaharashtraPageID)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra)));
            }
        }
        private void ItemCabinetMinisterTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            TeamMaharashtraPageID = "41";
            if (App.CurrentPage() != TeamMaharashtraPageID)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra)));
            }
        }
        private void ItemGovernorTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            TeamMaharashtraPageID = "40";
            if (App.CurrentPage() != TeamMaharashtraPageID)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra)));
            }
        }
        #endregion
        #region CMVisits methods
        private void ItemJalyuktaVisitsTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "jalyuktavisits")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMVisits.JalyuktaVisits)));
            }
        }
        private void ItemMaharashtraVisitsTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "maharashtravisits")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMVisits.MaharashtraVisitList)));
            }
        }
        private void ItemMakeInMaharashtraGoesInternationalTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "makeinmaharashtrainternational")
            {
                Application.Current.Properties["navigationflag"] = "0";
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMVisits.MakeInMaharashtraInternationalMain)));
            }
        }
        #endregion
        #region CMOFFICE methods
        private void ItemTeamCMO_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "teamcmo")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMOffice.TeamCMO)));
            }

        }
        private void ItemFormerCMTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "formercm")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMOffice.FormerCMs)));
            }

        }
        private void ItemContactCMOTap_Tapped(object sender, EventArgs e)
        {
            //Page displayPage = (Page)Activator.CreateInstance(typeof(CMO.CMOffice.Contact_CMO));
            //Detail.Navigation.PushAsync(displayPage);
            IsPresented = false;
            if (App.CurrentPage() != "contactcmo")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMOffice.Contact_CMO)));
            }

        }

        #endregion
        #region Join Us methods
        private void MyGovTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "mygov")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.JoinUs.MyGov)));
            }
        }
        private void SocialRespomsibilityCellTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "socialresponsibility")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.JoinUs.SocialResponsibilityCell)));
            }
        }
        private void CMInternshipProgramTap_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "cminternship")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.JoinUs.CMFellowShip)));
            }
        }
        private void CMsReliefFund_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            if (App.CurrentPage() != "cmrelieffund")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.CMOffice.CMReliefFund)));
            }
        }
        #endregion
        #region Module Tap MEthods
        private void HomeHeaderGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            HeaderStackHOME.BackgroundColor = Color.FromHex("#0c1337");
            IsPresented = false;
            if (App.CurrentPage() != "mahaapps")/*home*/
            {
                //this.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.MenuController.HomeScreen)));
                Application.Current.MainPage = new NavigationPage(new CMO.MenuController.MaharashtraCMO());
            }
            #region Visibility Module Items
            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void CMofficeHeaderGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            #region Visibility Module Items

            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            if (CMOfficeFlag == false)
            {
                CMOfficeFlag = true;
                STACKCMOffice.IsVisible = true;
                CMOfficeIMAGE.Source = "ico_down_arrow2.png";
                CMOfficeHEADER.TextColor = Color.FromHex("#f47421");
                HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#0c1337");
            }
            else if (CMOfficeFlag == true)
            {
                CMOfficeFlag = false;
                STACKCMOffice.IsVisible = false;
                CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
                CMOfficeHEADER.TextColor = Color.White;
                HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            }
            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            // CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region Set Default Color of all module names
            //CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            //HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void TheChiefMinisterGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            #region Visibility Module Items

            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            if (ChiefMinisterFlag == false)
            {
                ChiefMinisterFlag = true;
                STACKChiefMinister.IsVisible = true;
                ChiefMinisterIMAGE.Source = "ico_down_arrow2.png";
                ChiefMinisterHEADER.TextColor = Color.FromHex("#f47421");
                HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#0c1337");
            }
            else if (ChiefMinisterFlag == true)
            {
                ChiefMinisterFlag = false;
                STACKChiefMinister.IsVisible = false;
                ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
                ChiefMinisterHEADER.TextColor = Color.White;
                HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            }
            #endregion
            #region Set Down Arrow Image Defualt
            //  ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            //  ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            //  HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void CMsVisitHeaderGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            #region Visibility Module Items 

            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            if (CMVisitFlag == false)
            {
                CMVisitFlag = true;
                STACKCMVisit.IsVisible = true;
                CMVisitIMAGE.Source = "ico_down_arrow2.png";
                CMVisitHEADER.TextColor = Color.FromHex("#f47421");
                HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#0c1337");
            }
            else if (CMVisitFlag == true)
            {
                CMVisitFlag = false;
                STACKCMVisit.IsVisible = false;
                CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
                CMVisitHEADER.TextColor = Color.White;
                HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            }
            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            //    CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region  Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            //  CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            //  HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void JoinUsHeaderGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            #region Visibility Module Items

            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            if (JoinUsFlag == false)
            {
                JoinUsFlag = true;
                STACKJoinUs.IsVisible = true;
                JoinUsIMAGE.Source = "ico_down_arrow2.png";
                JoinUsHEADER.TextColor = Color.FromHex("#f47421");
                HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#0c1337");
            }
            else if (JoinUsFlag == true)
            {
                JoinUsFlag = false;
                STACKJoinUs.IsVisible = false;
                JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
                JoinUsHEADER.TextColor = Color.White;
                HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            }
            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            // JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region  Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            //    JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            //  HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void InitiativeHeaderGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            #region Visibility Module Items
            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            if (InitiativesFlag == false)
            {
                InitiativesFlag = true;
                STACKInitiatives.IsVisible = true;
                InitiativesIMAGE.Source = "ico_down_arrow2.png";
                InitiativesHEADER.TextColor = Color.FromHex("#f47421");
                HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#0c1337");
            }
            else if (InitiativesFlag == true)
            {
                InitiativesFlag = false;
                STACKInitiatives.IsVisible = false;
                InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
                InitiativesHEADER.TextColor = Color.White;
                HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            }
            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            //InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            // InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            //   HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void TeamMaharashtraHeaderGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            #region Visibility Module Items

            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            if (TeamMaharashtraFlag == false)
            {
                TeamMaharashtraFlag = true;
                STACKTeamMaharashtra.IsVisible = true;
                TeamMaharashtrasIMAGE.Source = "ico_down_arrow2.png";
                TeamMaharashtrasHEADER.TextColor = Color.FromHex("#f47421");
                HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#0c1337");
            }
            else if (TeamMaharashtraFlag == true)
            {
                TeamMaharashtraFlag = false;
                STACKTeamMaharashtra.IsVisible = false;
                TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
                TeamMaharashtrasHEADER.TextColor = Color.White;
                HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            }
            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            //  TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region  Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            //      TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            //   HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void GalleryHeaderGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            #region Visibility Module Items

            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;


            if (GalleryModuleFlag == false)
            {
                GalleryModuleFlag = true;
                STACKGalleryModule.IsVisible = true;
                GalleryModuleIMAGE.Source = "ico_down_arrow2.png";
                GalleryModuleHEADER.TextColor = Color.FromHex("#f47421");
                HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#0c1337");
            }
            else if (GalleryModuleFlag == true)
            {
                GalleryModuleFlag = false;
                STACKGalleryModule.IsVisible = false;
                GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
                GalleryModuleHEADER.TextColor = Color.White;
                HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            }
            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            //    GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region  Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            //  GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            //HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void ChangeLanguageHeaderTap_Tapped(object sender, EventArgs e)
        {
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#0c1337");
            IsPresented = false;
            if (App.CurrentPage() != "changelang")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.MenuController.ChangeLanguage)));
            }
            #region Visibility Module Items
            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void ApplicationListHeaderTap_Tapped(object sender, EventArgs e)
        {

            IsPresented = false;
            if (App.CurrentPage() != "application")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.MenuController.ApplicationList)));
            }
            #region Visibility Module Items
            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");

            #endregion
        }
        private void NewsFeedHeaderTap_Tapped(object sender, EventArgs e)
        {

            IsPresented = false;
            if (App.CurrentPage() != "newsfeed")
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CMO.MenuController.NewsFeedTabbedPage)));
            }
            #region Visibility Module Items
            CMOfficeFlag = false;
            STACKCMOffice.IsVisible = false;
            ChiefMinisterFlag = false;
            STACKChiefMinister.IsVisible = false;
            CMVisitFlag = false;
            STACKCMVisit.IsVisible = false;
            JoinUsFlag = false;
            STACKJoinUs.IsVisible = false;
            InitiativesFlag = false;
            STACKInitiatives.IsVisible = false;
            TeamMaharashtraFlag = false;
            STACKTeamMaharashtra.IsVisible = false;
            GalleryModuleFlag = false;
            STACKGalleryModule.IsVisible = false;


            #endregion
            #region Set Down Arrow Image Defualt
            ChiefMinisterIMAGE.Source = "ico_down_arrow2_right.png";
            InitiativesIMAGE.Source = "ico_down_arrow2_right.png";
            TeamMaharashtrasIMAGE.Source = "ico_down_arrow2_right.png";
            GalleryModuleIMAGE.Source = "ico_down_arrow2_right.png";
            JoinUsIMAGE.Source = "ico_down_arrow2_right.png";
            CMOfficeIMAGE.Source = "ico_down_arrow2_right.png";
            CMVisitIMAGE.Source = "ico_down_arrow2_right.png";
            ChangeLanguageIMAGE.Source = "ico_down_arrow2_right.png";

            #endregion
            #region Set Default Color of all module names
            CMOfficeHEADER.TextColor = Color.White;
            ChiefMinisterHEADER.TextColor = Color.White;
            InitiativesHEADER.TextColor = Color.White;
            TeamMaharashtrasHEADER.TextColor = Color.White;
            JoinUsHEADER.TextColor = Color.White;
            GalleryModuleHEADER.TextColor = Color.White;
            CMVisitHEADER.TextColor = Color.White;
            ChangeLanguageHEADERLABEL.TextColor = Color.White;

            #endregion
            #region set default color of module background on tap
            HeaderStackHOME.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMOffice.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChiefMinister.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKInitiatives.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKTeamMaharashtra.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKCMVisit.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKGalleryModule.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKJoinUs.BackgroundColor = Color.FromHex("#141b3d");
            HEADERSTACKChangeLanguage.BackgroundColor = Color.FromHex("#141b3d");


            #endregion
        }
        #endregion
    }
    public partial class MyMasterDetailPage : MasterDetailPage
    {
        public static readonly BindableProperty DrawerWidthProperty = BindableProperty.Create<MyMasterDetailPage, int>(p => p.DrawerWidth, default(int));

        public int DrawerWidth
        {
            get { return (int)GetValue(DrawerWidthProperty); }
            set { SetValue(DrawerWidthProperty, value); }
        }
    }
}
