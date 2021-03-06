﻿using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace CMO_UITest
{
	public class JoinUS : BasePage
	{
		public string ErrorMessage = string.Empty;
		readonly Query _backHeader;
		readonly Query _title;
		readonly Query _SahabhagSRC;
		readonly Query _SahabhagPage;
		readonly Query _CMFellowshipProgramme;
		readonly Query _CMFellowshipProgrammePage;
		readonly Query _CMReliefFund;
		readonly Query _CMReliefFundPage;
		readonly Query _MyGov;
		readonly Query _MyGovPage;
		readonly Query _JoinUs;


		public JoinUS(IApp app, Platform platform)
						: base(app, platform)
		{
			if (OnAndroid)
			{
				_title = x => x.Marked("lbl_JoinUs");
				_backHeader = x => x.Marked("Navigate up");
				_JoinUs = x => x.Marked("AJoinUsImage_Container");
				_SahabhagSRC = x => x.Marked("lbl_SocialResponsibilityCell");
				_SahabhagPage = x => x.Marked("Sahabhag - Social Responsibility Cell");
				_CMFellowshipProgramme = x => x.Marked("lbl_CMsInternshipProgram");
				_CMFellowshipProgrammePage = x => x.Marked("Chief Minister's Fellowship Programme");
				_CMReliefFund = x => x.Marked("lbl_CMsReliefFund");
				_CMReliefFundPage = x => x.Marked("CMReleifFund");
				_MyGov = x => x.Marked("lbl_MyGov");
				_MyGovPage = x => x.Marked("MyGov");
			}
		}

		public string JoinUsNav()
		{
			try
			{
				app.Tap(_backHeader);
				app.WaitForElement(_title, "", TimeSpan.FromSeconds(3));
				app.Screenshot("menu tapped");

				app.Tap(_title);
				app.WaitForElement(_SahabhagSRC, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Join Us Navigation menu tapped");

				app.Tap(_SahabhagSRC);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Sahabhag  - Social Responsibility Cell Navigation menu tapped");

				app.Tap(_backHeader);
				app.Tap(_CMFellowshipProgramme);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Chief Minister's Fellowship programme Navigation menu tapped");

				app.Tap(_backHeader);
				app.Tap(_CMReliefFund);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Chief Minister's Relief Fund Navigation menu tapped");

				app.Tap(_backHeader);
				app.Tap(_MyGov);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("MyGov Navigation menu tapped");

				app.Tap(_backHeader);
				app.Tap(_title);

			}
			catch (Exception ex) { Assert.Fail("Error occur on Join Us Page " + ex.Message); }
			return ErrorMessage;
		}


		public string JoinUs()
		{
			try
			{
				app.Tap(_JoinUs);
				app.WaitForElement(_backHeader,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Join Us page");

				app.ScrollDown();
				app.Screenshot("Join US Scrolled Down page");

				//app.Repl();

				app.Tap(_SahabhagPage);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Sahabhag - Social Responsibility Cell page");

				app.Tap(_backHeader);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Sahabhag - Social Responsibility Cell page header back tapped");

				app.Tap(_CMFellowshipProgrammePage);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Chief Minister's Fellowship programme page");

				app.Tap(_backHeader);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Chief Minister's Fellowship programme page header back tapped");

				//app.Repl();

				app.Tap(_CMReliefFundPage);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Chief Minister's Relief Fund page");

				app.Tap(_backHeader);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Chief Minister's Relief Fund page header back tapped");

				app.Tap(_MyGovPage);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(5));
				app.Screenshot("MyGov page");

				app.Tap(_backHeader);
				app.WaitForElement(_backHeader, "", TimeSpan.FromSeconds(3));
				app.Screenshot("MyGov page header back tapped");

				app.Tap(_backHeader);
				app.WaitForElement(_JoinUs, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Home Page ");

			}
			catch (Exception ex) { Assert.Fail("Error occur on Join Us Page " + ex.Message); }
			return ErrorMessage;
		}

	}
}
