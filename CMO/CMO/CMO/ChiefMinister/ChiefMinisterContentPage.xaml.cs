using CMO.MenuController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.ChiefMinister
{
    public partial class ChiefMinisterContentPage : ContentPage
    {
        public static string TeamMaharashtraPageID;
        public string Module_name;
        public ChiefMinisterContentPage(string _modulename)
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.Android)
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                    imgHeader.HeightRequest = App.DeviceHeight * 0.40;
                else
                    imgHeader.HeightRequest = App.DeviceHeight * 0.40;
            }
			if (Device.OS == TargetPlatform.iOS)
			{
				if (Device.Idiom == TargetIdiom.Phone)
                    imgHeader.HeightRequest = App.DeviceHeight * 0.40;

                if (Device.Idiom == TargetIdiom.Tablet)
                    imgHeader.HeightRequest = 420;
            }
			setfontsize();
            NavigationPage.SetBackButtonTitle(this, "");
            Module_name = _modulename;
        }
        protected override async void OnAppearing()
        {
            setfontcolor();
            await DataBindingList(Module_name);
        }
        protected override void OnDisappearing()
        {
            setfontcolor();
        }
        public async void TapContentItem(object sender, EventArgs args)
		{
			var tappeditem = sender as StackLayout;
		 	CMO.MenuController.SideMenu.TeamMaharashtraPageID = tappeditem.ClassId;
            var pid = CMO.MenuController.SideMenu.TeamMaharashtraPageID;
            if (pid == "40") ContentLabel1.TextColor = Color.FromHex("#f47421");
            else if (pid == "41") ContentLabel2.TextColor = Color.FromHex("#f47421");
            else if (pid == "42") ContentLabel3.TextColor = Color.FromHex("#f47421");
            else if (pid == "43") ContentLabel4.TextColor = Color.FromHex("#f47421");
            else if (pid == "44") ContentLabel5.TextColor = Color.FromHex("#f47421");
            else if (pid == "45") ContentLabel6.TextColor = Color.FromHex("#f47421");
            else if (pid == "47") ContentLabel7.TextColor = Color.FromHex("#f47421");
            await Navigation.PushAsync(new CMO.TeamMaharashtra.Comman_WebView_TeamMaharashtra());
		}
		public async void CMTapContentItem(object sender, EventArgs args)
		{
			var tappeditem = sender as StackLayout;
			if (tappeditem.ClassId == "ChiefMinister1")
			{
                CMContentLabel1.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.ChiefMinister.Biography());
            }
            else if (tappeditem.ClassId == "ChiefMinister2")
			{
                CMContentLabel2.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.ChiefMinister.VisionMissionOath());
			}
			else if (tappeditem.ClassId == "ChiefMinister3")
			{
                CMContentLabel3.TextColor = Color.FromHex("#f47421");
                openurl("http://www.devendrafadnavis.in/index.html");
			}
		}
		public async void CMVisitTapContentItem(object sender, EventArgs args)
		{
			var tappeditem = sender as StackLayout;
	         Application.Current.Properties["navigationflag"] = "0";
			if (tappeditem.ClassId == "CMVisit1")
			{
                CMVisitContentLabel1.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.CMVisits.MakeInMaharashtraInternationalMain());
			}
			else if (tappeditem.ClassId == "CMVisit2")
			{
                CMVisitContentLabel2.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.CMVisits.MaharashtraVisitList());
			}
			else if (tappeditem.ClassId == "CMVisit3")
			{
                CMVisitContentLabel3.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.CMVisits.JalyuktaVisits());;
			}
			else if (tappeditem.ClassId == "CMVisit4")
			{
                CMVisitContentLabel4.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.CMVisits.Eventslists());
			}

		}
		public async void JoinUsTapContentItem(object sender, EventArgs args)
		{
			var tappeditem = sender as StackLayout;
            if (tappeditem.ClassId == "https://aaplesarkar.maharashtra.gov.in/")
            {
                JoinUsContentLabel1.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.JoinUs.ApleSarkar());
            }
            else if (tappeditem.ClassId == "http://14.141.36.213/srcportal/")
            {
                JoinUsContentLabel2.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.JoinUs.SocialResponsibilityCell());
            }
            else if (tappeditem.ClassId == "https://mahades.maharashtra.gov.in/FELLOWSHIP/english/about.html")
            {
                JoinUsContentLabel3.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.JoinUs.CMFellowShip());
            }
            else if (tappeditem.ClassId == "CMReleifFund")
            {
                JoinUsContentLabel4.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.CMOffice.CMReliefFund());
            }
            else if (tappeditem.ClassId == "MyGov")
            {
                JoinUsContentLabel5.TextColor = Color.FromHex("#f47421");
                await Navigation.PushAsync(new CMO.JoinUs.MyGov());
            }
            // openurl(tappeditem.ClassId);
        }

        public async void InitiativesTapContentItem(object sender, EventArgs args)
        {
            var tappeditem = sender as StackLayout;
            CMO.MenuController.SideMenu.InitiativesCurrentPageName = tappeditem.ClassId;
            if (tappeditem.ClassId == "aapleSarkarRow")      InitiativesContentLabel1.TextColor = Color.FromHex("#f47421");
            else if (tappeditem.ClassId == "droughtfreeRow") InitiativesContentLabel2.TextColor = Color.FromHex("#f47421");
            else if (tappeditem.ClassId == "swachhRow")      InitiativesContentLabel3.TextColor = Color.FromHex("#f47421");
            else if (tappeditem.ClassId == "makeinRow")      InitiativesContentLabel4.TextColor = Color.FromHex("#f47421");
            else if (tappeditem.ClassId == "skilldevRow")    InitiativesContentLabel5.TextColor = Color.FromHex("#f47421");
            else if (tappeditem.ClassId == "righttoservRow") InitiativesContentLabel6.TextColor = Color.FromHex("#f47421");
            else if (tappeditem.ClassId == "digitalRow")     InitiativesContentLabel7.TextColor = Color.FromHex("#f47421");
            else if (tappeditem.ClassId == "cmmasRow")       InitiativesContentLabel8.TextColor = Color.FromHex("#f47421");
            await Navigation.PushAsync(new CMO.Initiatives.InitiativesMain());
        }
        public void openurl(string url)
        {Device.OpenUri(new Uri(url));}
        private async Task DataBindingList(string modulename)
        {
            string lang = "";
            if (Application.Current.Properties.ContainsKey("Language"))
            { lang = Application.Current.Properties["Language"] as string; }

            if (modulename == "CM")
            {
                this.Title = AppResources.LTheChiefMinister;
                DataStack.Padding = new Thickness(10, 10, 0, 0);
                imgHeader.Source = "the_chief_minister_next.png";
                if(lang == "en")
                  await CallWebService("27");
                else
                  await CallWebService("27");
                lblName.Text = AppResources.LChiefMinisterName;
                CheifMinisterStack.IsVisible = true;
                TeamMaharashtraStack.IsVisible = false;
                CMVisitStack.IsVisible = false;
                InitiativesStack.IsVisible = false;
                JoinUsStack.IsVisible = false;
            }
            else if (modulename == "TM")
            {
                this.Title = AppResources.LTeamMaharashtra;
				DataStack.Padding = new Thickness(0, 0, 0, 0);
                lblName.IsVisible = false;
                imgHeader.Source = "team_maha_next.png";
                if (lang == "en")
                    await CallWebService("31");
                else
                    await CallWebService("31");
                CheifMinisterStack.IsVisible = false;
                TeamMaharashtraStack.IsVisible = true;
                CMVisitStack.IsVisible = false;
                JoinUsStack.IsVisible = false;
                InitiativesStack.IsVisible = false;
            }
            else if (modulename == "CMV")
            {
                this.Title = AppResources.LCmVisits;
				DataStack.Padding = new Thickness(0, 0, 0, 0);
                lblName.IsVisible = false;
                imgHeader.Source = "cm_visit_next.png";
                if (lang == "en")
                    await CallWebService("29");
                else
                    await CallWebService("29");
                CheifMinisterStack.IsVisible = false;
                TeamMaharashtraStack.IsVisible = false;
                CMVisitStack.IsVisible = true;
                JoinUsStack.IsVisible = false;
                InitiativesStack.IsVisible = false;
            }
			else if (modulename == "JU")
			{
				this.Title = AppResources.LJoinUs.ToUpper();
				DataStack.Padding = new Thickness(0, 0, 0, 0);
				lblName.IsVisible = false;
				imgHeader.Source = "join_us_next.png";
                if (lang == "en")
                    await CallWebService("28");
                else
                    await CallWebService("28");
                JoinUsStack.IsVisible = true; 
                CheifMinisterStack.IsVisible = false;
                TeamMaharashtraStack.IsVisible = false;
                CMVisitStack.IsVisible = false;
                InitiativesStack.IsVisible = false;
            }
            else if (modulename == "Initiative")
            {
                this.Title = AppResources.LInitiativesTitle.ToUpper();
                DataStack.Padding = new Thickness(0, 0, 0, 0);
                lblName.IsVisible = false;
                imgHeader.Source = "initiatives_next.png";
                if (lang == "en")
                    await CallWebService("30");
                else
                    await CallWebService("30");
                InitiativesStack.IsVisible = true;
                JoinUsStack.IsVisible = false;
                CheifMinisterStack.IsVisible = false;
                TeamMaharashtraStack.IsVisible = false;
                CMVisitStack.IsVisible = false;
            }

        }
		public void setfontsize()
		{
			lblName.FontSize = App.GetFontSizeTitle();
			lblDescription.FontSize = App.GetFontSizeSmall();

			CMVisitContentLabel1.FontSize = App.GetFontSizeSmall();
			CMVisitContentLabel2.FontSize = App.GetFontSizeSmall();
			CMVisitContentLabel3.FontSize = App.GetFontSizeSmall();
			CMVisitContentLabel4.FontSize = App.GetFontSizeSmall();

			CMContentLabel1.FontSize = App.GetFontSizeSmall();
			CMContentLabel2.FontSize = App.GetFontSizeSmall();
			CMContentLabel3.FontSize = App.GetFontSizeSmall();

			JoinUsContentLabel1.FontSize = App.GetFontSizeSmall();
			JoinUsContentLabel2.FontSize = App.GetFontSizeSmall();
			JoinUsContentLabel3.FontSize = App.GetFontSizeSmall();
            JoinUsContentLabel4.FontSize = App.GetFontSizeSmall();
            JoinUsContentLabel5.FontSize = App.GetFontSizeSmall();

            ContentLabel1.FontSize = App.GetFontSizeSmall();
			ContentLabel2.FontSize = App.GetFontSizeSmall();
			ContentLabel3.FontSize = App.GetFontSizeSmall();
			ContentLabel4.FontSize = App.GetFontSizeSmall();
			ContentLabel5.FontSize = App.GetFontSizeSmall();
			ContentLabel6.FontSize = App.GetFontSizeSmall();
		    ContentLabel7.FontSize = App.GetFontSizeSmall();

            InitiativesContentLabel1.FontSize = App.GetFontSizeSmall();
            InitiativesContentLabel2.FontSize = App.GetFontSizeSmall();
            InitiativesContentLabel3.FontSize = App.GetFontSizeSmall();
            InitiativesContentLabel4.FontSize = App.GetFontSizeSmall();
            InitiativesContentLabel5.FontSize = App.GetFontSizeSmall();
            InitiativesContentLabel6.FontSize = App.GetFontSizeSmall();
            InitiativesContentLabel7.FontSize = App.GetFontSizeSmall();
            InitiativesContentLabel8.FontSize = App.GetFontSizeSmall();

        }
        public void setfontcolor()
        {
            CMVisitContentLabel1.TextColor = Color.FromHex("#484848");
            CMVisitContentLabel2.TextColor = Color.FromHex("#484848");
            CMVisitContentLabel3.TextColor = Color.FromHex("#484848");
            CMVisitContentLabel4.TextColor = Color.FromHex("#484848");

            CMContentLabel1.TextColor = Color.FromHex("#484848");
            CMContentLabel2.TextColor = Color.FromHex("#484848");
            CMContentLabel3.TextColor = Color.FromHex("#484848");

            JoinUsContentLabel1.TextColor = Color.FromHex("#484848");
            JoinUsContentLabel2.TextColor = Color.FromHex("#484848");
            JoinUsContentLabel3.TextColor = Color.FromHex("#484848");
            JoinUsContentLabel4.TextColor = Color.FromHex("#484848");
            JoinUsContentLabel5.TextColor = Color.FromHex("#484848");

            ContentLabel1.TextColor = Color.FromHex("#484848");
            ContentLabel2.TextColor = Color.FromHex("#484848");
            ContentLabel3.TextColor = Color.FromHex("#484848");
            ContentLabel4.TextColor = Color.FromHex("#484848");
            ContentLabel5.TextColor = Color.FromHex("#484848");
            ContentLabel6.TextColor = Color.FromHex("#484848");
            ContentLabel7.TextColor = Color.FromHex("#484848");

            InitiativesContentLabel1.TextColor = Color.FromHex("#484848");
            InitiativesContentLabel2.TextColor = Color.FromHex("#484848");
            InitiativesContentLabel3.TextColor = Color.FromHex("#484848");
            InitiativesContentLabel4.TextColor = Color.FromHex("#484848");
            InitiativesContentLabel5.TextColor = Color.FromHex("#484848");
            InitiativesContentLabel6.TextColor = Color.FromHex("#484848");
            InitiativesContentLabel7.TextColor = Color.FromHex("#484848");
            InitiativesContentLabel8.TextColor = Color.FromHex("#484848");
        }

        private async Task CallWebService(string block_id)
        {
            if (!App.CheckInternetConnection())
            {
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            }
            else
            {
                try
                {
                    List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("block_id", block_id));
                    var response = await GeneralClass.GetResponse<RootObject>(CMO.ServiceLayer.ServiceLinks.webviewBlockContentURL, values);
                    if (response != null)
                    {
                        if (response._resultflag == 1)
                        {
                            var webcontent = response.block_content;
                            Regex pRegex = new Regex("<p.*?(?=</p>)", RegexOptions.IgnoreCase);
                            // if text is not single line use this regex
                            // Regex pRegex = new Regex("<p.*?(?=</p>), RegexOptions.SingleLine"); 
                            var result = pRegex.Match(webcontent).Value;
                            result = Regex.Replace(result, "<.*?>", string.Empty);
                            lblDescription.Text = result;
                            MainStack.IsVisible = true;
                        }
                        else
                        {
                            await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
                        }
                    }
                    else
                    {
                        await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
                    }
                }
                catch (WebException ex)
                {
                   if (ex.Message.Contains("Network"))
                      await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                }
            }
            loading.IsRunning = false; loading.IsVisible = false;
        }
        public class RootObject
        {
            public int _resultflag { get; set; }
            public string block_subject { get; set; }
            public string block_content { get; set; }
        }
        #region Exit Application
        private bool _canClose = true;

        //protected override bool OnBackButtonPressed()
        //{
        //    Application.Current.MainPage = new SideMenu();
        //    return true;
        //}

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
    }
    public class ContentPagesCMO
    {
        public string ListTitle { get; set; }
        public ImageSource photoicon_path { get; set; }
        public string FlagValue { get; set; }
        public string navigateTo { get; set; } 
		public int SetFontSize { get; set; }
    }

    public class TextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
				return Color.White;
            }
            else
            {
				return Color.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            // so from color to yes no or maybe
            throw new NotImplementedException();
        }
    }

   
}
