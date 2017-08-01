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
	public class Team_Maharashtra : BasePage
	{
		public string ErrorMessage = string.Empty;
		readonly Query _CMInAction;
		readonly Query _title;
		readonly Query _MenuBtn;
		readonly Query _backHeader;
		readonly Query _TeamMaharashtra;
		readonly Query _Governor;
		readonly Query _CabinetMinister;
		readonly Query _StateMinister;
		readonly Query _ChiefJustice;
		readonly Query _Secretaries;
		readonly Query _Collectors;
		readonly Query _GovDep;


		public Team_Maharashtra(IApp app, Platform platform)
						: base(app, platform)
			{
			if (OnAndroid)
			{

				_MenuBtn = x => x.Marked("Navigate up");
				_CMInAction = x => x.Marked("AlblCMVISIT_Container");
				_title = x => x.Text("TEAM MAHARASHTRA");
				_backHeader = x => x.Marked("Navigate up");
				_TeamMaharashtra = x => x.Marked("AlblTEAMMAHARSHTRA_Container");
				_Governor = x => x.Text("Governor");
				_CabinetMinister = x => x.Text("Cabinet Ministers");
				_StateMinister = x => x.Text("State Ministers");
				_ChiefJustice = x => x.Text("Chief Justice");
				_Secretaries = x => x.Text("Secretaries");
				_Collectors = x => x.Text("Collectors");
				_GovDep = x => x.Text("Government Departments");

			}
		}

		public string TeamMaharashtraNav()
		{
			try 
			{
				app.Tap(_MenuBtn);
				app.WaitForElement(_title, "", TimeSpan.FromSeconds(3));
				app.Repl();
				app.Tap(_title);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Team Maharashtra tapped");

				app.Tap(_Governor);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Governor page openned");

				app.Tap(_MenuBtn);
				app.WaitForElement(_CabinetMinister, "", TimeSpan.FromSeconds(3));
				app.Tap(_CabinetMinister);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Cabinet Minister page openned");


				app.Tap(_MenuBtn);
				app.WaitForElement(_StateMinister, "", TimeSpan.FromSeconds(3));
				app.Tap(_StateMinister);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("State Minister page openned");


				app.Tap(_MenuBtn);
				app.WaitForElement(_ChiefJustice, "", TimeSpan.FromSeconds(3));
				app.Tap(_ChiefJustice);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Chief Justice page openned");


				app.Tap(_MenuBtn);
				app.WaitForElement(_Secretaries, "", TimeSpan.FromSeconds(3));
				app.Tap(_Secretaries);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Secretaries page openned");


				app.Tap(_MenuBtn);
				app.WaitForElement(_Collectors, "", TimeSpan.FromSeconds(3));
				app.Tap(_Collectors);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Collectors page openned");


				app.Tap(_MenuBtn);
				app.WaitForElement(_GovDep, "", TimeSpan.FromSeconds(3));
				app.Tap(_GovDep);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Government Departments page openned");

				app.Tap(_MenuBtn);
				app.Tap(_title);

			}
			catch (Exception ex) { Assert.Fail("Error occur on Team Maharashtra Page " + ex.Message); }
			return ErrorMessage;
		}

		public string TeamMaharashtra()
		{
			try
			{

				app.Tap(_TeamMaharashtra);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Team Maharashtra page");

				app.Tap(_Governor);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Governor page");

				app.Tap(_backHeader);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(3));

				app.Tap(_CabinetMinister);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Cabinate Ministers page");

				app.Tap(_backHeader);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(3));

				app.Tap(_StateMinister);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("State Ministers page");

				app.Tap(_backHeader);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(3));

				app.Tap(_ChiefJustice);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Chief Justice page");

				app.Tap(_backHeader);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(3));

				app.Tap(_Secretaries);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Secertaries page");

				app.Tap(_backHeader);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(5));


				app.ScrollDown();
				app.Screenshot("Team Maharashtra Page Scrolled down");

				app.Tap(_Collectors);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Collectors page");

				app.Tap(_backHeader);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(3));

				app.Tap(_GovDep);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Government Departments page");

				app.Tap(_backHeader);
				app.WaitForElement(_Governor, "", TimeSpan.FromSeconds(3));

				app.Tap(_backHeader);
				app.WaitForElement(_MenuBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Home page");

			}
			catch (Exception ex) { Assert.Fail("Error occur on Team Maharashtra Page " + ex.Message); }
			return ErrorMessage;
		}


		
	}
}
