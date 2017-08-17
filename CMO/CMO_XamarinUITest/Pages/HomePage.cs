using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace CMO_UITest
{
	public class HomePage : BasePage
	{
		//First Page/Main page 
		#region
		public string ErrorMessage = string.Empty;

		readonly Query _slider;
		readonly Query _slide1;
		readonly Query _MahaCOM;
		readonly Query _Mahavitaran;
		readonly Query _MahaExplorer;
		readonly Query _MSRTC;
		readonly Query _MahaNews;
		readonly Query _GoM_GR;
		readonly Query _slide2;
		readonly Query _Lokrajya;
		readonly Query _MOLBarCode;
		readonly Query _FAQ;
		readonly Query _AapleSarkar;
		readonly Query _Accessible;
		readonly Query _MCGM;
		readonly Query _slide3;
		readonly Query _PuneConnect;
		readonly Query _SmartNashik;
		readonly Query _NMCComplaints;
		readonly Query _GeoTrack;
		readonly Query _PollutionControl;
		readonly Query _NMMCCitizen;
		readonly Query _slide4;
		readonly Query _SmartKDMC;
		readonly Query _MyCIDCO;
		readonly Query _WCD;
		#endregion

		//Home page
		#region
		readonly Query _MenuBtn;
		readonly Query _CMInAction;
		readonly Query _TeamMaharastra;
		readonly Query _backHeader;
		readonly Query _Initiatives;
		readonly Query _JoinUs;
		readonly Query _NewsUpdates;
		readonly Query _NewsBtn;
		readonly Query _PhotoBtn;
		readonly Query _VideoBtn;
		#endregion

		public HomePage(IApp app, Platform platform)
						: base(app, platform)
			{
			if (OnAndroid)
			{
				//First Page
				#region
				_slider = x => x.Marked("pager");
				_slide1 = x => x.Marked("Unselected0_Container");
				_MahaCOM = x => x.Marked("AItm1_Grid");
				_Mahavitaran = x => x.Marked("AItm2_Grid");
				_MahaExplorer = x => x.Marked("AItm3_Grid");
				_MSRTC = x => x.Marked("AItm4_Grid");
				_MahaNews = x => x.Marked("AItm5_Grid");
				_GoM_GR = x => x.Marked("AItm6_Grid");
				_slide2 = x => x.Marked("Unselected1_Container");
				_Lokrajya = x => x.Marked("AItm1_Grid");
				_MOLBarCode = x => x.Marked("AItm2_Grid");
				_FAQ = x => x.Marked("AItm3_Grid");
				_AapleSarkar = x => x.Marked("AItm4_Grid");
				_Accessible = x => x.Marked("AItm5_Grid");
				_MCGM = x => x.Marked("AItm6_Grid");
				_slide3 = x => x.Marked("Unselected2_Container");
				_PuneConnect = x => x.Marked("AItm1_Grid");
				_SmartNashik = x => x.Marked("AItm2_Grid");
				_NMCComplaints = x => x.Marked("AItm3_Grid");
				_GeoTrack = x => x.Marked("AItm4_Grid");
				_PollutionControl = x => x.Marked("AItm5_Grid");
				_NMMCCitizen = x => x.Marked("AItm6_Grid");
				_slide4 = x => x.Marked("Unselected3_Container");
				_SmartKDMC = x => x.Marked("AItm1_Grid");
				_MyCIDCO = x => x.Marked("AItm2_Grid");
				_WCD = x => x.Marked("AItm3_Grid");
				#endregion

				//Home page
				#region 
				_MenuBtn = x => x.Marked("Navigate up");
				_CMInAction = x => x.Marked("AlblCMVISIT_Container");
				_TeamMaharastra = x => x.Marked("AlblTEAMMAHARSHTRA_Container");
				_backHeader = x => x.Marked("Navigate up");
				_Initiatives = x => x.Marked("AlblINITIATIVES_Container");
				_JoinUs = x => x.Marked("AlblJOINUS_Container");
				_NewsUpdates = x => x.Marked("AlblNEWS_Container");
				_NewsBtn = x => x.Marked("AbtnNEWS");
				_PhotoBtn = x => x.Marked("AlblPHOTO");
				_VideoBtn = x => x.Marked("AbtnVIDEO");
				#endregion

			}
		}
		public string AppLaunches()
		{
			try
			{
				//app.Repl();
				app.Screenshot("First screen.");
				app.WaitForElement(_slider,"",TimeSpan.FromSeconds(8));
				app.SwipeRightToLeft(_slide2);
				app.Screenshot("First Page Swipped Rigth to Left");
				app.SwipeRightToLeft(_slide3);
				app.Screenshot("Second Page Swipped Rigth to Left");
				app.SwipeRightToLeft(_slide4);
				app.Screenshot("Third Page Swipped Rigth to Left");


			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur on First Page " + ex.Message);
			}
			return ErrorMessage;
		}

	}
}