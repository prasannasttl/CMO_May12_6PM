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
	public class MeetTheCM : BasePage
	{
		public string ErrorMessage = string.Empty;
		//Meet The CM
		#region
		readonly Query _MeetCM;
		readonly Query _meetTheCM;
		readonly Query _MenuBtn;
		readonly Query _backHeader;
		readonly Query _Header;
		readonly Query _Biography;
		readonly Query _VisionAndMission;
		readonly Query _BioPage;
		readonly Query _VisionPage;
		#endregion

		public MeetTheCM(IApp app, Platform platform)
						: base(app, platform)
		{
			if (OnAndroid)
			{
				//Meet the CM
				#region
				_MenuBtn = x => x.Marked("Navigate up");
				_MeetCM = x => x.Marked("AlblCHIEFMINISTER_Container");
				_meetTheCM = x => x.Marked("lbl_MeetCM");
				_backHeader = x => x.Marked("Navigate up");
				_Header = x => x.Marked("action_bar").Text("MEET THE CHIEF MINISTER");
				_Biography = x => x.Marked("lbl_Biography");
				_VisionAndMission = x => x.Marked("lbl_VissionMissionOath");
				_BioPage = x => x.Text("Biography");
				_VisionPage = x => x.Text("Vision and Mission");

				#endregion
			}
		}


		//Meet the CM Navigation Drawer
		#region
		public string MeetTheCMNav()
		{
			try
			{
				//app.Repl();
				app.Tap(_MenuBtn);
				app.WaitForElement(_meetTheCM,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Navigation Drawer Openned");

				app.Tap(_meetTheCM);
				app.WaitForElement(_Biography,"",TimeSpan.FromSeconds(3));
				app.Screenshot("Meet the CM tapped");
				app.Tap(_Biography);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Biography page selected");

				app.Tap(_MenuBtn);
				app.WaitForElement(_Biography,"",TimeSpan.FromSeconds(3));
				app.Screenshot("Meet the CM tapped");

				app.Tap(_VisionAndMission);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Vision and Mission selected");


			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur on Meet the Chief Minister Navigation Drawer " + ex.Message);
			}
			return ErrorMessage;
		}
		#endregion


		//Meet the CM
		#region
		public string MeetCM()
		{
			try
			{

				app.Tap(_MeetCM);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Meet The CM");
				//app.Repl();
				app.Tap(_BioPage);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Biographt page");


				app.Back();
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(15));

				app.Tap(_VisionPage);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Vision and Mission page");

				app.Tap(_backHeader);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Meet the CM page");

				app.Back();
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Meet the CM page header back tapped");


			}
			catch (Exception ex) { Assert.Fail("Error occur on Meet the Chief Minister Page " + ex.Message); }
			return ErrorMessage;		}
		
		#endregion
	}
}
