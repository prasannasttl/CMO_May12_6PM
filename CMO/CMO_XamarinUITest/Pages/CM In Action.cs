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
	public class CM_In_Action : BasePage 
	{
		public string ErrorMessage = string.Empty;
		readonly Query _CMInAction;
		readonly Query _title;
		readonly Query _MenuBtn;
		readonly Query _backHeader;
		readonly Query _menuscroll;

		readonly Query _International;
		readonly Query _China;

		readonly Query _Domestic;
		readonly Query _List;


		public CM_In_Action(IApp app, Platform platform)
						: base(app, platform)
		{
			if (OnAndroid)
			{

				_MenuBtn = x => x.Marked("Navigate up");
				_CMInAction = x => x.Marked("AlblCMVISIT_Container");
				_title = x => x.Marked("CM IN ACTION");
				_backHeader = x => x.Marked("Navigate up");
				_menuscroll = x => x.Marked("nav_scroll");

				_International = x => x.Text("International");
				_China = x => x.Text("China Visit");

				_Domestic = x => x.Text("Domestic");
				_List = x => x.Text("BEED");
			}
		}


		public string CMInActionNav()
		{
			try 
			{
				app.Tap(_MenuBtn);
				app.WaitForElement(_title, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Drawer Menu oppened");

				app.ScrollDown(_menuscroll);
				app.Screenshot("Drawer Layout Scrolled Down");

				app.Tap(_title);
				app.WaitForElement(_International, "", TimeSpan.FromSeconds(3));
				app.Screenshot("CM In Action navigation drawer tapped");

				app.Tap(_International);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Internation Page oppened");

				app.Tap(_MenuBtn);
				app.Tap(_Domestic);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Domestic Page oppened");

				app.Tap(_MenuBtn);
				app.Tap(_title);

			}
			catch (Exception ex) { Assert.Fail("Error occur on Chief Minister In Action Page " + ex.Message); }
			return ErrorMessage;
		}

		public string CMInAction()
		{
			try
			{

				app.Tap(_CMInAction);
				app.WaitForElement(_Domestic, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Chief Minister in Action Selected");

				app.Tap(_International);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("International page");

				app.Tap(_backHeader);
				app.WaitForElement(_Domestic, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Header Back Key pressed");

				app.Tap(_Domestic);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Domestic page");

				app.Tap(_backHeader);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(5));

				app.Back();

			}
			catch (Exception ex) { Assert.Fail("Error occur on Chief Minister In Action Page " + ex.Message); }
			return ErrorMessage;
		}

	}
}
