using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.MenuController
{
    public partial class SideMenuContent : ContentPage
    {
        public StackLayout SIDEMENUMainStack { get {return SideMenuMainStack;} }
        #region 0 HOME
        public Label HOMEHeader { get { return HomeHeader; } }
        public StackLayout HeaderStackHOME { get { return HeaderStackHome; } }
        #endregion
        #region 1 for  CMOffice module 
        public Image CMOfficeIMAGE { get { return CMOfficeImage; } }
        public Label CMOfficeHEADER { get { return CMOfficeHeader; } }
        public StackLayout STACKCMOffice { get { return StackCMOffice; } }
        public StackLayout HEADERSTACKCMOffice { get { return HeaderStackCMOffice; } }
        public Label ITEMTeamCMO { get { return ItemTeamCMO; } }
        public Label ITEMFormerCMs { get { return ItemFormerCMs; } }
        public Label ITEMCMsReliefFund { get { return ItemCMsReliefFund; } }
        public Label ITEMContactCMO { get { return ItemContactCMO; } }
        #endregion
        #region 2 for  The Chief Minister module 
        public Image ChiefMinisterIMAGE { get { return ChiefMinisterImage; } }
        public Label ChiefMinisterHEADER { get { return ChiefMinisterHeader; } }
        public StackLayout STACKChiefMinister { get { return StackCheifMinister; } }
        public Grid HEADERSTACKChiefMinister { get { return HeaderStackChiefMinister; } }
        public Label ITEMBiography { get { return ItemBiography; } }
        public Label ITEMVissionMissionOath { get { return ItemVissionMissionOath; } }
        public Label ITEMPersonalWebsite { get { return ItemPersonalWebsite; } }

        #endregion
        #region 3 for  Initiatives module 
        public Image InitiativesIMAGE { get { return InititiativesImage; } }
        public Label InitiativesHEADER { get { return InititiativesHeader; } }
        public StackLayout STACKInitiatives { get { return StackInitiatives; } }
        public StackLayout HEADERSTACKInitiatives { get { return HeaderStackInitiatives; } }
        public Label ITEMApleSarkar { get { return ItemApleSarkar; } }
        public Label ITEMDroughtFreeMaharashtra { get { return ItemDroughtFreeMaharashtra; } }
        public Label ITEMSwatchMaharashtra { get { return ItemSwatchMaharashtra; } }
        public Label ITEMMakeInMaharashtra { get { return ItemMakeInMaharashtra; } }
        public Label ITEMSkillDevelopment { get { return ItemSkillDevelopment; } }
        public Label ITEMRightToService { get { return ItemRightToService; } }
        public Label ITEMDigitalMaharashtra { get { return ItemDigitalMaharashtra; } }
        public Label ITEMChiefMinistersAssistance { get { return ItemChiefMinistersAssistance; } }

        #endregion
        #region 4 for  TeamMaharashtra module 
        public Image TeamMaharashtrasIMAGE { get { return TeamMaharashtraImage; } }
        public Label TeamMaharashtrasHEADER { get { return TeamMaharashtraHeader; } }
        public StackLayout STACKTeamMaharashtra { get { return StackTeamMaharashtra; } }
        public StackLayout HEADERSTACKTeamMaharashtra { get { return HeaderStackTeamMaharashtra; } }
        public Label ITEMGoverner { get { return ItemGoverner; } }
        public Label ITEMCabinetMinister { get { return ItemCabinetMinister; } }
        public Label ITEMStateMinister { get { return ItemStateMinister; } }
        public Label ITEMChiefJustice { get { return ItemChiefJustice; } }
        public Label ITEMSecretaries { get { return ItemSecretaries; } }
        public Label ITEMCOllectors { get { return ItemCollectors; } }
        public Label ITEMGovtDepartment { get { return ItemGovtDepartment; } }
        #endregion
        #region 5 for  Join Us module 
        public Image JoinUsIMAGE { get { return JoinUsImage; } }
        public Label JoinUsHEADER { get { return JoinUsHeader; } }
        public StackLayout STACKJoinUs { get { return StackJoinUs; } }
        public StackLayout HEADERSTACKJoinUs { get { return HeaderStackJoinUs; } }
       
        public Label ITEMSocialResponsibilityCell { get { return ItemSocialResponsibilityCell; } }
        public Label ITEMCMsInternshipProgram { get { return ItemCMsInternshipProgram; } }
        public Label ITEMMyGov { get { return ItemMyGov; } }
        

        #endregion
        #region 6  for CMVisit module 
        public Image CMVisitIMAGE { get { return CMVisitImage; } }
        public Label CMVisitHEADER { get { return CMVisitHeader; } }
        public StackLayout STACKCMVisit { get { return StackCMVisit; } }
        public StackLayout HEADERSTACKCMVisit { get { return HeaderStackCMVisit; } }
        public Label ITEMMakeInMaharashtraGoesInternational { get { return ItemMakeInMaharashtraGoesInternational; } }
        public Label ITEMMaharashtraVisits { get { return ItemMaharashtraVisits; } }
        public Label ITEMJalyuktaVisit { get { return ItemJalyuktaVisit; } }
        public Label ITEMEvents { get { return ItemEvents; } }

        #endregion
        #region 7 for  Gallery module 
        public Image GalleryModuleIMAGE { get { return MediaGalleryImage; } }
        public Label GalleryModuleHEADER { get { return MediaGalleryHeader; } }
        public StackLayout STACKGalleryModule { get { return StackMediaGallery; } }
        public StackLayout HEADERSTACKGalleryModule { get { return HeaderStackMediaGallery; } }
        public Label ITEMNewsGallery { get { return ItemNewsGallery; } }
        public Label ITEMMagazineGallery { get { return ItemMagazineGallery; } }
        public Label ITEMPhotoGallery { get { return ItemPhotoGallery; } }
        public Label ITEMVideoGallery { get { return ItemVideoGallery; } }
        public Label ITEMPressReleases { get { return ItemPressReleases; } }
        public Label ITEMPressClips { get { return ItemPressClip; } }

        #endregion
        #region 8 Change Language 
        public StackLayout HEADERSTACKChangeLanguage { get { return ChangeLanguageStackHeader; } }
        public Label ChangeLanguageHEADERLABEL { get { return ChangeLanguageHeaderLabel; } }
    
        public Image ChangeLanguageIMAGE { get { return ChangeLanguageImage; } }
     
     
        #endregion
        #region Menu
        public Label MENUHeader { get { return MenuHeader; } }
        #endregion
     
        public SideMenuContent()
        {
            InitializeComponent();
			setFontSize();
        }

		public void setFontSize()
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
			ITEMCMsReliefFund.FontSize = App.GetFontSizeSmall();
			ITEMContactCMO.FontSize = App.GetFontSizeSmall();
			#endregion

			#region 2 for  The Chief Minister module
			ITEMBiography.FontSize = App.GetFontSizeSmall();
			ITEMVissionMissionOath.FontSize = App.GetFontSizeSmall();
			ITEMPersonalWebsite.FontSize = App.GetFontSizeSmall();
			#endregion

			#region 3 for  Initiatives module 
			#endregion

        	#region 4 for  TeamMaharashtra module 
			ITEMGoverner.FontSize = App.GetFontSizeSmall();
			ITEMCabinetMinister.FontSize = App.GetFontSizeSmall();
			ITEMStateMinister.FontSize = App.GetFontSizeSmall();
			ITEMChiefJustice.FontSize = App.GetFontSizeSmall();
			ITEMSecretaries.FontSize = App.GetFontSizeSmall();
			ITEMCOllectors.FontSize = App.GetFontSizeSmall();
			ITEMGovtDepartment.FontSize = App.GetFontSizeSmall();
            #endregion

            #region 5 for  Join Us module 
            ITEMApleSarkar.FontSize = App.GetFontSizeSmall();
            ITEMSocialResponsibilityCell.FontSize = App.GetFontSizeSmall();
            ITEMCMsInternshipProgram.FontSize = App.GetFontSizeSmall();
            #endregion

            #region 6  for CMVisit module 
            ITEMMakeInMaharashtraGoesInternational.FontSize = App.GetFontSizeSmall();
			ITEMMaharashtraVisits.FontSize = App.GetFontSizeSmall();
			ITEMJalyuktaVisit.FontSize = App.GetFontSizeSmall();
			ITEMEvents.FontSize = App.GetFontSizeSmall();
			#endregion

			#region 7 for  Gallery module 
			ITEMNewsGallery.FontSize = App.GetFontSizeSmall();
			ITEMMagazineGallery.FontSize = App.GetFontSizeSmall();
			ITEMPhotoGallery.FontSize = App.GetFontSizeSmall();
			ITEMVideoGallery.FontSize = App.GetFontSizeSmall();
			ITEMPressReleases.FontSize = App.GetFontSizeSmall();
            ITEMPressClips.FontSize = App.GetFontSizeSmall();
			#endregion
		}

    }
    

    #region Interface to get action bar height
    public interface IActionBarHeight
    {
        string GetActionBarHeight();
    }
    #endregion

}
