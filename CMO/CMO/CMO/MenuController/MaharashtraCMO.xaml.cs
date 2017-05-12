using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.MenuController
{
	public partial class MaharashtraCMO : ContentPage
	{

		#region Binding Variables
		public List<GovApps> MOREAPPSLIST;
		public List<GovApps> MoreAppsList { get; set; } // Must have default value or be set before the BindingContext is set.
		private int _position;
		public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

		#endregion
		public MaharashtraCMO()
		{
			InitializeComponent();
			//BannerButton.FontSize = App.GetFontSizeMedium();
			MahaGov.FontSize = App.GetFontSizeTitle();
		}
		protected override void OnAppearing()
		{
			Application.Current.Properties["CurrentPage"] = "mahaapps";
			ApplicationListBinding();
			MoreAppsList = MOREAPPSLIST;
			BindingContext = this;
		}
		private DateTime GetDate(string m_d_yyyy_date)
		{
			string myFormattedDateTime = DateTime.ParseExact(
								m_d_yyyy_date,
								"M/d/yyyy",
								System.Globalization.CultureInfo.InvariantCulture)
							 .ToString("MM/dd/yyyy");
			return DateTime.ParseExact(myFormattedDateTime, "MM/dd/yyyy", null);
		}
		public void ApplicationListBinding()
		{
			var ApplicattionList = new List<ApplicationData>();
			#region Binding List For Android
			if (TargetPlatform.Android == Device.OS)
			{
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "Maha CMO", PackageName = "com.MahaCMO", Icon = "icon", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "Mahavitaran", PackageName = "com.msedcl.app", Icon = "AppMahaVitran", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "Maha Explorer", PackageName = "com.mtdc.mtdcapp", Icon = "AppMahaExplorer", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "MSRTC", PackageName = "com.expscs.msrtc", Icon = "AppMSRTC_Mobile_Reservation_App", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "MahaNews", PackageName = "in.gov.mahanews", Icon = "AppMahaNews", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "GoM GR, The Official App", PackageName = "in.gov.maharashtra.govtresolutions", Icon = "AppMaharashtra_Govt_Resolutions", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "Lokrajya", PackageName = "com.news.lokrajya", Icon = "AppLokrajya_Magazine", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "MOLBarCode", PackageName = "in.mol.barcodeScanner", Icon = "AppMahaOnline_Barcode_Scanner", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "FAQ", PackageName = "com.crystalhitech.faq", Icon = "AppFAQS", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "Aaple Sarkar", PackageName = "com.aaplesarkar", Icon = "AppAaple_Sarkar", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "Accessible Places", PackageName = "com.celerapp.redpanda.accessibleplaces", Icon = "AppAccessible_Places", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "MCGM 24X7", PackageName = "in.cdac.gov.mgov.mcgm", Icon = "AppMCGM", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "PuneConnect", PackageName = "io.cordova.pmcpunefirst", Icon = "AppPuneConnect", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "Smart Nashik", PackageName = "com.swt.nmc.smartnashik", Icon = "AppSmart_Nashik", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "NMC Complaints", PackageName = "com.SWT.NMCComplaints", Icon = "AppNMC_Complaint_App", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "GeoTrack", PackageName = "thane.android.com.thaneapp", Icon = "AppGeotrack", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "PollutionControl", PackageName = "com.pollutioncontrol", Icon = "AppPollutionControl", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "NMMC Citizen App", PackageName = "com.mars.nmmc_citizen", Icon = "AppNMMC_Citizen_App", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "SmartKDMC", PackageName = "com.abm.smartkdmc", Icon = "AppSmartKDMC", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "MyCIDCO", PackageName = "com.mycidco", Icon = "AppMyCIDCO", URL = "", AppStatus = "" });
				ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(), Name = "WCD", PackageName = "wcd.crystalhitech.com.wcd", Icon = "AppWCD_Anganwadi", URL = "", AppStatus = "" });
			}
			#endregion
			#region Binding List For iOS
			if (TargetPlatform.iOS == Device.OS)
			{
				//        //   ApplicattionList.Add(new ApplicationData() { Name = "Mahavitaran", PackageName = "com.msedcl.app", Icon = "http://a3.mzstatic.com/us/r30/Purple18/v4/60/92/b8/6092b8a9-d125-9a09-9b9e-facb0297cf4e/icon175x175.jpeg",
				//    //           URL = "https://itunes.apple.com/in/app/mahavitaran-consumer-app/id1128838189?mt=8", AppStatus = "" });
				//        //   ApplicattionList.Add(new ApplicationData() { Name = "Maha Explorer", PackageName = "com.mtdc.mtdcapp", Icon = "", URL = "", AppStatus = "" });
				//     //      ApplicattionList.Add(new ApplicationData() { Name = "MSRTC", PackageName = "com.expscs.msrtc", Icon = "http://a5.mzstatic.com/us/r30/Purple/v4/a8/6d/5f/a86d5f4a-81f4-fa98-074a-88ff8c93f66e/icon175x175.jpeg",
				//      //         URL = "https://itunes.apple.com/in/app/msrtc/id788426884?mt=8", AppStatus = "" });
				//      //     ApplicattionList.Add(new ApplicationData() { Name = "MahaNews", PackageName = "in.gov.mahanews", Icon = "http://a5.mzstatic.com/us/r30/Purple/v4/f5/48/66/f5486642-1b1b-7258-887b-08d37e2fd8d8/icon175x175.png",
				//       //        URL = "https://itunes.apple.com/in/app/mahanews/id871107735?mt=8", AppStatus = "" });
				//           ApplicattionList.Add(new ApplicationData() {SetFontSize = App.GetFontSizeMedium(), Name = "GoM GR, The Official App", PackageName = "in.gov.maharashtra.govtresolutions", Icon = "http://a1.mzstatic.com/us/r30/Purple1/v4/a2/cd/65/a2cd6530-2881-2ef3-2f0d-73b182128922/icon175x175.png",
				//               URL = "https://itunes.apple.com/in/app/maharashtra-govt.-resolutions/id1015385492?mt=8http://a1.mzstatic.com/us/r30/Purple1/v4/a2/cd/65/a2cd6530-2881-2ef3-2f0d-73b182128922/icon175x175.png", AppStatus = "" });
				//      //     ApplicattionList.Add(new ApplicationData() { Name = "Lokrajya", PackageName = "com.news.lokrajya", Icon = "", URL = "", AppStatus = "" });
				//        //   ApplicattionList.Add(new ApplicationData() { Name = "MOLBarCode", PackageName = "in.mol.barcodeScanner", Icon = "", URL = "", AppStatus = "" });
				//           ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(),
				//Name = "FAQ", PackageName = "com.crystalhitech.faq", Icon = "http://a2.mzstatic.com/us/r30/Purple49/v4/2b/14/fc/2b14fc70-4759-e850-8fc8-a9d62b332d2d/icon175x175.png",
				//               URL = "https://itunes.apple.com/us/app/faqs-on-local-body-elections/id1071809672?mt=8", AppStatus = "" });
				//           ApplicattionList.Add(new ApplicationData() {SetFontSize = App.GetFontSizeMedium(), Name = "Aaple Sarkar", PackageName = "com.aaplesarkar", Icon = "http://a4.mzstatic.com/us/r30/Purple69/v4/0c/8a/0f/0c8a0fe2-0c38-206e-cbd8-84a42f90f0a1/icon175x175.png",
				//               URL = "https://itunes.apple.com/in/app/aaple-sarkar/id964411876?mt=8", AppStatus = "" });
				////    ApplicattionList.Add(new ApplicationData() { Name = "Accessible Places", PackageName = "com.celerapp.redpanda.accessibleplaces", Icon = "", URL = "", AppStatus = "" });
				//           ApplicattionList.Add(new ApplicationData() { SetFontSize = App.GetFontSizeMedium(),
				//Name = "MCGM 24X7", PackageName = "in.cdac.gov.mgov.mcgm", Icon = "http://a1.mzstatic.com/us/r30/Purple20/v4/18/68/ab/1868abc8-d58f-3f96-0766-c441de77d953/icon175x175.png",
				//               URL = "https://itunes.apple.com/in/app/mcgm-24x7/id982888250?mt=8", AppStatus = "" });
				//           ApplicattionList.Add(new ApplicationData() {SetFontSize = App.GetFontSizeMedium(), Name = "PuneConnect", PackageName = "io.cordova.pmcpunefirst", Icon = "http://a3.mzstatic.com/us/r30/Purple71/v4/18/50/08/18500871-4c19-8f8f-fb7f-64f7083a3caa/icon175x175.jpeg",
				//               URL = "https://itunes.apple.com/in/app/puneconnect/id1073608394?mt=8", AppStatus = "" });
				//           ApplicattionList.Add(new ApplicationData() {SetFontSize = App.GetFontSizeMedium(), Name = "Smart Nashik", PackageName = "com.swt.nmc.smartnashik", Icon = "http://a4.mzstatic.com/us/r30/Purple49/v4/50/a3/96/50a396f8-f076-fcf9-7987-97d8fa61f944/icon175x175.jpeg",
				//               URL = "https://itunes.apple.com/in/app/smart-nashik/id1102398897?mt=8", AppStatus = "" });
				//           //   ApplicattionList.Add(new ApplicationData() { Name = "NMC Complaints", PackageName = "com.SWT.NMCComplaints", Icon = "", URL = "", AppStatus = "" });
				//           //    ApplicattionList.Add(new ApplicationData() { Name = "GeoTrack", PackageName = "thane.android.com.thaneapp", Icon = "http://a3.mzstatic.com/us/r30/Purple62/v4/8f/00/a2/8f00a2d3-a39d-55b4-f301-ebee88488045/icon175x175.png",
				//           //       URL = "https://itunes.apple.com/in/app/geotrack-tmc/id1159341578?mt=8", AppStatus = "" });
				//           //   ApplicattionList.Add(new ApplicationData() { Name = "PollutionControl", PackageName = "com.pollutioncontrol", Icon = "", URL = "", AppStatus = "" });
				//           //    ApplicattionList.Add(new ApplicationData() { Name = "NMMC Citizen App", PackageName = "com.mars.nmmc_citizen", Icon = "NMMC_Citizen_App.png", URL = "", AppStatus = "" });
				//           //   ApplicattionList.Add(new ApplicationData() { Name = "SmartKDMC", PackageName = "com.abm.smartkdmc", Icon = "", URL = "", AppStatus = "" });
				//           //   ApplicattionList.Add(new ApplicationData() { Name = "CIDCO", PackageName = "in.gov.maharashtra.cidco.cidco2", Icon = "", URL = "", AppStatus = "" });
				//           //   ApplicattionList.Add(new ApplicationData() { Name = "WCD", PackageName = "wcd.crystalhitech.com.wcd", Icon = "http://a4.mzstatic.com/us/r30/Purple62/v4/82/f7/db/82f7dbed-2f1b-62ae-c27e-08edfa87634f/icon175x175.jpeg",
				//           //   URL = "https://itunes.apple.com/in/app/wcd-anganwadi-mobile-app/id1154408213?mt=8", AppStatus = "" });


				#region temporary data
				ApplicattionList.Add(new ApplicationData()
				{
					SetFontSize = App.GetFontSizeMedium(),
					Name = "Maha CMO",
					URL = "",
					Icon = "icon",
					PackageName = "com.MahaCMO",
					AppStatus = ""
				});
				ApplicattionList.Add(new ApplicationData()
				{
					SetFontSize = App.GetFontSizeMedium(),
					Name = "GoM GR, The Official App",
					URL = "in.gov.maharashtra.govtresolutions",
					Icon = "http://a1.mzstatic.com/us/r30/Purple1/v4/a2/cd/65/a2cd6530-2881-2ef3-2f0d-73b182128922/icon175x175.png",
					PackageName = "https://itunes.apple.com/in/app/maharashtra-govt.-resolutions/id1015385492?mt=8http://a1.mzstatic.com/us/r30/Purple1/v4/a2/cd/65/a2cd6530-2881-2ef3-2f0d-73b182128922/icon175x175.png",
					AppStatus = ""
				});
				ApplicattionList.Add(new ApplicationData()
				{
					SetFontSize = App.GetFontSizeMedium(),
					Name = "FAQ",
					URL = "com.crystalhitech.faq",
					Icon = "http://a2.mzstatic.com/us/r30/Purple49/v4/2b/14/fc/2b14fc70-4759-e850-8fc8-a9d62b332d2d/icon175x175.png",
					PackageName = "https://itunes.apple.com/us/app/faqs-on-local-body-elections/id1071809672?mt=8",
					AppStatus = ""
				});
				ApplicattionList.Add(new ApplicationData()
				{
					SetFontSize = App.GetFontSizeMedium(),
					Name = "Aaple Sarkar",
					URL = "com.aaplesarkar",
					Icon = "http://a4.mzstatic.com/us/r30/Purple69/v4/0c/8a/0f/0c8a0fe2-0c38-206e-cbd8-84a42f90f0a1/icon175x175.png",
					PackageName = "https://itunes.apple.com/in/app/aaple-sarkar/id964411876?mt=8",
					AppStatus = ""
				});
				ApplicattionList.Add(new ApplicationData()
				{
					SetFontSize = App.GetFontSizeMedium(),
					Name = "MCGM 24X7",
					URL = "in.cdac.gov.mgov.mcgm",
					Icon = "http://a1.mzstatic.com/us/r30/Purple20/v4/18/68/ab/1868abc8-d58f-3f96-0766-c441de77d953/icon175x175.png",
					PackageName = "https://itunes.apple.com/in/app/mcgm-24x7/id982888250?mt=8",
					AppStatus = ""
				});
				ApplicattionList.Add(new ApplicationData()
				{
					SetFontSize = App.GetFontSizeMedium(),
					Name = "PuneConnect",
					URL = "io.cordova.pmcpunefirst",
					Icon = "http://a3.mzstatic.com/us/r30/Purple71/v4/18/50/08/18500871-4c19-8f8f-fb7f-64f7083a3caa/icon175x175.jpeg",
					PackageName = "https://itunes.apple.com/in/app/puneconnect/id1073608394?mt=8",
					AppStatus = ""
				});
				ApplicattionList.Add(new ApplicationData()
				{
					SetFontSize = App.GetFontSizeMedium(),
					Name = "Smart Nashik",
					URL = "com.swt.nmc.smartnashik",
					Icon = "http://a4.mzstatic.com/us/r30/Purple49/v4/50/a3/96/50a396f8-f076-fcf9-7987-97d8fa61f944/icon175x175.jpeg",
					PackageName = "https://itunes.apple.com/in/app/smart-nashik/id1102398897?mt=8",
					AppStatus = ""
				});


				#endregion
			}
			#endregion
			//src="http://a4.mzstatic.com/us/r30/Purple69/v4/0c/8a/0f/0c8a0fe2-0c38-206e-cbd8-84a42f90f0a1/icon175x175.png"
			for (int i = 0; i < ApplicattionList.Count; i++)
			{
				if (TargetPlatform.Android == Device.OS)
				{
					if (DependencyService.Get<IIsAppInstalled>().IsAppInstalled(ApplicattionList[i].PackageName))
					{
						ApplicattionList[i].AppStatus = "INSTALLED";
					}
					else
					{
						ApplicattionList[i].AppStatus = "INSTALL";
					}
					ApplicattionList[i].SetButtonSize = 100;
				}

				if (TargetPlatform.iOS == Device.OS)
				{
					if (DependencyService.Get<IIsAppInstalled>().IsAppInstalled(ApplicattionList[i].URL))
					{
						ApplicattionList[i].AppStatus = "INSTALLED";
					}
					else
					{
						ApplicattionList[i].AppStatus = "INSTALL";
					}
					if (ApplicattionList[i].URL == "") { ApplicattionList[i].AppStatus = "INSTALLED"; }
					if (Device.Idiom == TargetIdiom.Phone)
					{ ApplicattionList[i].SetButtonSize = 83; }
					else
					{
						ApplicattionList[i].SetButtonSize = 100;
					}
					//  ApplicattionList[i].URL = ApplicattionList[i].PackageName; // tempeporary code
				}

			}
			SliderListBinding(ApplicattionList);
		}
		private void SliderListBinding(List<ApplicationData> AppListing)
		{
			MOREAPPSLIST = new List<GovApps>();
			for (int i = 0; i < AppListing.Count; i++)
			{
				var objApp = new GovApps();
				if (TargetPlatform.iOS == Device.OS)
				{
					if (Device.Idiom == TargetIdiom.Phone)
					{
						objApp.TickMarkMargin = new Thickness(0, -8, 25, 0);
					}
					else
					{
						objApp.TickMarkMargin = new Thickness(0, -5, 70, 0);
					}
				}
				else
				{
					objApp.TickMarkMargin = new Thickness(0, -8, 32, 0);
				}

				#region Bind First Image
				objApp.Itm1_Name = AppListing[i].Name;
				objApp.Itm1_PackageName = AppListing[i].PackageName;
				objApp.Itm1_URL = AppListing[i].URL;
				objApp.Itm1_Icon = AppListing[i].Icon;
				objApp.Itm1_AppStatus = AppListing[i].AppStatus;
				objApp.Itm1_ButtonTap = AppListing[i].ButtonTap;
				objApp.SetFontSize = AppListing[i].SetFontSize;
				#endregion
				#region Bind Second Image
				i++;
				if (i < AppListing.Count)
				{
					objApp.Itm2_Name = AppListing[i].Name;
					objApp.Itm2_PackageName = AppListing[i].PackageName;
					objApp.Itm2_URL = AppListing[i].URL;
					objApp.Itm2_Icon = AppListing[i].Icon;
					objApp.Itm2_AppStatus = AppListing[i].AppStatus;
					objApp.Itm2_ButtonTap = AppListing[i].ButtonTap;
					objApp.SetFontSize = AppListing[i].SetFontSize;
				}
				else
				{
					objApp.Itm2_Name = null;
					objApp.Itm2_PackageName = null;
					objApp.Itm2_URL = null;
					objApp.Itm2_Icon = null;
					objApp.Itm2_AppStatus = null;
					objApp.Itm2_ButtonTap = null;
					//objApp.SetFontSize = 0;
				}
				#endregion
				#region Bind Third Image
				i++;
				if (i < AppListing.Count)
				{
					objApp.Itm3_Name = AppListing[i].Name;
					objApp.Itm3_PackageName = AppListing[i].PackageName;
					objApp.Itm3_URL = AppListing[i].URL;
					objApp.Itm3_Icon = AppListing[i].Icon;
					objApp.Itm3_AppStatus = AppListing[i].AppStatus;
					objApp.Itm3_ButtonTap = AppListing[i].ButtonTap;
					objApp.SetFontSize = AppListing[i].SetFontSize;
				}
				else
				{
					objApp.Itm3_Name = null;
					objApp.Itm3_PackageName = null;
					objApp.Itm3_URL = null;
					objApp.Itm3_Icon = null;
					objApp.Itm3_AppStatus = null;
					objApp.Itm3_ButtonTap = null;
					//objApp.SetFontSize = 0;
				}
				#endregion
				#region Bind Fourth Image
				i++;
				if (i < AppListing.Count)
				{
					objApp.Itm4_Name = AppListing[i].Name;
					objApp.Itm4_PackageName = AppListing[i].PackageName;
					objApp.Itm4_URL = AppListing[i].URL;
					objApp.Itm4_Icon = AppListing[i].Icon;
					objApp.Itm4_AppStatus = AppListing[i].AppStatus;
					objApp.Itm4_ButtonTap = AppListing[i].ButtonTap;
					objApp.SetFontSize = AppListing[i].SetFontSize;
				}
				else
				{
					objApp.Itm4_Name = null;
					objApp.Itm4_PackageName = null;
					objApp.Itm4_URL = null;
					objApp.Itm4_Icon = null;
					objApp.Itm4_AppStatus = null;
					objApp.Itm4_ButtonTap = null;
					//objApp.SetFontSize = 0;
				}
				#endregion
				#region Bind Fifth Image
				i++;
				if (i < AppListing.Count)
				{
					objApp.Itm5_Name = AppListing[i].Name;
					objApp.Itm5_PackageName = AppListing[i].PackageName;
					objApp.Itm5_URL = AppListing[i].URL;
					objApp.Itm5_Icon = AppListing[i].Icon;
					objApp.Itm5_AppStatus = AppListing[i].AppStatus;
					objApp.Itm5_ButtonTap = AppListing[i].ButtonTap;
					objApp.SetFontSize = AppListing[i].SetFontSize;
				}
				else
				{
					objApp.Itm5_Name = null;
					objApp.Itm5_PackageName = null;
					objApp.Itm5_URL = null;
					objApp.Itm5_Icon = null;
					objApp.Itm5_AppStatus = null;
					objApp.Itm5_ButtonTap = null;
					//objApp.SetFontSize = 0;
				}
				#endregion
				#region Bind Sixth Image
				i++;
				if (i < AppListing.Count)
				{
					objApp.Itm6_Name = AppListing[i].Name;
					objApp.Itm6_PackageName = AppListing[i].PackageName;
					objApp.Itm6_URL = AppListing[i].URL;
					objApp.Itm6_Icon = AppListing[i].Icon;
					objApp.Itm6_AppStatus = AppListing[i].AppStatus;
					objApp.Itm6_ButtonTap = AppListing[i].ButtonTap;
					objApp.SetFontSize = AppListing[i].SetFontSize;
				}
				else
				{
					objApp.Itm6_Name = null;
					objApp.Itm6_PackageName = null;
					objApp.Itm6_URL = null;
					objApp.Itm6_Icon = null;
					objApp.Itm6_AppStatus = null;
					objApp.Itm6_ButtonTap = null;
					//objApp.SetFontSize = 0;
				}
				#endregion
				MOREAPPSLIST.Add(objApp);
			}
		}
		public void CMOfficeTap(object sender, EventArgs args)
		{
			Application.Current.MainPage = new SideMenu();
		}

		#region Application Tapped  Events
		public async void App1Tap(object sender, EventArgs args)
		{
			var AppSelected = sender as Grid;
			var objApp = AppSelected.BindingContext as GovApps;
			var pckgName = objApp.Itm1_PackageName;
			var statApp = objApp.Itm1_AppStatus;
			if (Device.OS == TargetPlatform.Android)
			{
				if (statApp == "INSTALLED")
				{
					if ((pckgName == "com.MahaCMO") || (pckgName == "com.MahaCMO.V2") || (pckgName == "com.MahaCMO.V1"))
					{
						Application.Current.MainPage = new SideMenu();
					}
					else
						DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
				}
				else if (statApp == "INSTALL")
					DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(pckgName))
					{
						if (pckgName == "com.MahaCMO")
						{
							Application.Current.MainPage = new SideMenu();
						}
						else
						{
							Device.OpenUri(new Uri(pckgName));
						}
					}
					else { }
				}
				catch (Exception e)
				{
					await DisplayAlert(AppResources.LNetworkError, e.Message, AppResources.LOk);
				}
			}
		}
		public async void App2Tap(object sender, EventArgs args)
		{
			var AppSelected = sender as Grid;
			var objApp = AppSelected.BindingContext as GovApps;
			var pckgName = objApp.Itm2_PackageName;
			var statApp = objApp.Itm2_AppStatus;
			if (Device.OS == TargetPlatform.Android)
			{
				if (statApp == "INSTALLED")
				{
					if (pckgName == "com.MahaCMO") ;
					else
						DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
				}
				else if (statApp == "INSTALL")
					DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(pckgName))
						Device.OpenUri(new Uri(pckgName));
					else { }
				}
				catch (Exception e)
				{
					await DisplayAlert(AppResources.LNetworkError, e.Message, AppResources.LOk);
				}
			}
		}
		public async void App3Tap(object sender, EventArgs args)
		{
			var AppSelected = sender as Grid;
			var objApp = AppSelected.BindingContext as GovApps;
			var pckgName = objApp.Itm3_PackageName;
			var statApp = objApp.Itm3_AppStatus;
			if (Device.OS == TargetPlatform.Android)
			{
				if (statApp == "INSTALLED")
				{
					if (pckgName == "com.MahaCMO") ;
					else
						DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
				}
				else if (statApp == "INSTALL")
					DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(pckgName))
						Device.OpenUri(new Uri(pckgName));
					else { }
				}
				catch (Exception e)
				{
					await DisplayAlert(AppResources.LNetworkError, e.Message, AppResources.LOk);
				}
			}
		}
		public async void App4Tap(object sender, EventArgs args)
		{
			var AppSelected = sender as Grid;
			var objApp = AppSelected.BindingContext as GovApps;
			var pckgName = objApp.Itm4_PackageName;
			var statApp = objApp.Itm4_AppStatus;
			if (Device.OS == TargetPlatform.Android)
			{
				if (statApp == "INSTALLED")
				{
					if (pckgName == "com.MahaCMO") ;
					else
						DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
				}
				else if (statApp == "INSTALL")
					DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(pckgName))
						Device.OpenUri(new Uri(pckgName));
					else { }
				}
				catch (Exception e)
				{
					await DisplayAlert(AppResources.LNetworkError, e.Message, AppResources.LOk);
				}
			}
		}
		public async void App5Tap(object sender, EventArgs args)
		{
			var AppSelected = sender as Grid;
			var objApp = AppSelected.BindingContext as GovApps;
			var pckgName = objApp.Itm5_PackageName;
			var statApp = objApp.Itm5_AppStatus;
			if (Device.OS == TargetPlatform.Android)
			{
				if (statApp == "INSTALLED")
				{
					if (pckgName == "com.MahaCMO") ;
					else
						DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
				}
				else if (statApp == "INSTALL")
					DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(pckgName))
						Device.OpenUri(new Uri(pckgName));
					else { }
				}
				catch (Exception e)
				{
					await DisplayAlert(AppResources.LNetworkError, e.Message, AppResources.LOk);
				}
			}
		}
		public async void App6Tap(object sender, EventArgs args)
		{
			var AppSelected = sender as Grid;
			var objApp = AppSelected.BindingContext as GovApps;
			var pckgName = objApp.Itm6_PackageName;
			var statApp = objApp.Itm6_AppStatus;
			if (Device.OS == TargetPlatform.Android)
			{
				if (statApp == "INSTALLED")
				{
					if (pckgName == "com.MahaCMO") ;
					else
						DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
				}
				else if (statApp == "INSTALL")
					DependencyService.Get<IIsAppInstalled>().NavigatePage(pckgName);
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(pckgName))
						Device.OpenUri(new Uri(pckgName));
					else { }
				}
				catch (Exception e)
				{
					await DisplayAlert(AppResources.LNetworkError, e.Message, AppResources.LOk);
				}
			}
		}
		#endregion
		#region Exit Application
		private bool _canClose = true;

		protected override bool OnBackButtonPressed()
		{

			if (_canClose)
			{
				ShowExitDialog();
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
	}


	public class GovApps
	{
		#region Application Name
		public string Itm1_Name { get; set; }
		public string Itm2_Name { get; set; }
		public string Itm3_Name { get; set; }
		public string Itm4_Name { get; set; }
		public string Itm5_Name { get; set; }
		public string Itm6_Name { get; set; }
		#endregion
		#region Package Name
		public string Itm1_PackageName { get; set; }
		public string Itm2_PackageName { get; set; }
		public string Itm3_PackageName { get; set; }
		public string Itm4_PackageName { get; set; }
		public string Itm5_PackageName { get; set; }
		public string Itm6_PackageName { get; set; }
		#endregion
		#region URL
		public string Itm1_URL { get; set; }
		public string Itm2_URL { get; set; }
		public string Itm3_URL { get; set; }
		public string Itm4_URL { get; set; }
		public string Itm5_URL { get; set; }
		public string Itm6_URL { get; set; }
		#endregion
		#region Icon
		public string Itm1_Icon { get; set; }
		public string Itm2_Icon { get; set; }
		public string Itm3_Icon { get; set; }
		public string Itm4_Icon { get; set; }
		public string Itm5_Icon { get; set; }
		public string Itm6_Icon { get; set; }
		#endregion
		#region Application Status
		public string Itm1_AppStatus { get; set; }
		public string Itm2_AppStatus { get; set; }
		public string Itm3_AppStatus { get; set; }
		public string Itm4_AppStatus { get; set; }
		public string Itm5_AppStatus { get; set; }
		public string Itm6_AppStatus { get; set; }
		#endregion
		#region button tap
		public string Itm1_ButtonTap { get; set; }
		public string Itm2_ButtonTap { get; set; }
		public string Itm3_ButtonTap { get; set; }
		public string Itm4_ButtonTap { get; set; }
		public string Itm5_ButtonTap { get; set; }
		public string Itm6_ButtonTap { get; set; }
		#endregion
		#region Font Size
		public int SetFontSize { get; set; }
		public Thickness TickMarkMargin { get; set;}
		#endregion
	}

	public class TickMarkIconVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value != null)
			{
				switch (value.ToString())
				{
					case "INSTALL":
						return false;
					case "INSTALLED":
						return true;
					case "OPEN":
						return true;
				}
			}
			return false;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
