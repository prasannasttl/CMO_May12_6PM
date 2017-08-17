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
	public class ChangeLanguage : BasePage
	{
		public string ErrorMessage = string.Empty;
		readonly Query _menuBtn;
		readonly Query _ChangeLanguage;
		readonly Query _titleEnglish;
		readonly Query _titleMarathi;
		readonly Query _langEng;
		readonly Query _engBtn;
		readonly Query _langMarathi;
		readonly Query _marathiBtn;
		readonly Query _home;

		public ChangeLanguage(IApp app, Platform platform)
						: base(app, platform)
		{
			if (OnAndroid)
			{
				_menuBtn = x => x.Marked("Navigate up");
				_ChangeLanguage = x => x.Marked("lbl_Changelanguage");
				_titleEnglish = x => x.Marked("action_bar").Text("CHANGE LANGUAGE");
				_titleMarathi = x => x.Marked("action_bar").Text("भाषा बदला");
				_langEng = x => x.Marked("English");
				_engBtn = x => x.Marked("btn_EnglishChangeLanguageSwitch");
				_langMarathi = x => x.Marked("मराठी");
				_marathiBtn = x => x.Marked("btn_MarathiChangeLanguageSwitch");
				_home = x => x.Marked("lbl_Home");

			}
		}

		public string ChangeLang()
		{
			try
			{
				app.Repl();

				app.Tap(_ChangeLanguage);
				app.WaitForElement(_langEng, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Change Language page");

				app.Tap(_engBtn);
				app.WaitForElement(_marathiBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("English Toggle button tapped");

				app.Tap(_marathiBtn);
				app.WaitForElement(_engBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Marathi language Toggle Button tapped");

				app.Tap(_menuBtn);
				app.Tap(_home);

			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Change Language Page " + ex.Message);
			}
			return ErrorMessage;
		}
	}
}
