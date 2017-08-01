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
	public class Initiatives : BasePage
	{
		public string ErrorMessage = string.Empty;
		readonly Query _menuBtn;
		readonly Query _titleInitiatives;
		readonly Query _AapleSarkarPRP;
		readonly Query _JalyuktaShivarDFM;
		readonly Query _SwachhMaharashtra;
		readonly Query _MakeinMaharashtra;
		readonly Query _SkillDevelopment;
		readonly Query _RighttoService;
		readonly Query _DigitalMaharashtra;
		readonly Query _CMMedicalAssistanceCell;

		readonly Query _Initiatives;

		public Initiatives(IApp app, Platform platform)
						: base(app, platform)
		{
			if (OnAndroid)
			{
				_menuBtn = x => x.Marked("Navigate up");
				_titleInitiatives = x => x.Marked("lbl_Initiatives");

				_Initiatives = x => x.Marked("AlblINITIATIVES_Container");

				_AapleSarkarPRP = x => x.Text("Aaple Sarkar - Public Redressal Portal");
				_JalyuktaShivarDFM = x => x.Text("Jalyukta Shivar - Drought-free Maharashtra");
				_SwachhMaharashtra = x => x.Text("Swachh Maharashtra");
				_MakeinMaharashtra = x => x.Text("Make in Maharashtra");
				_SkillDevelopment = x => x.Text("Skill Development");
				_RighttoService = x => x.Text("Right to Service");
				_DigitalMaharashtra = x => x.Text("Digital Maharashtra");
				_CMMedicalAssistanceCell = x => x.Text("Chief Minister's Medical Assistance Cell");
			}
		}


		public string InitiativesNav()
		{
			try
			{
				
				app.Tap(_menuBtn);
				app.WaitForElement(_titleInitiatives, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Navigation Drawer Menu oppened");
				app.Repl();
				app.Tap(_titleInitiatives);
				app.WaitForElement(_AapleSarkarPRP,"",TimeSpan.FromSeconds(3));
				app.Screenshot("Initiatives selected");

				app.Tap(_AapleSarkarPRP);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Aaple Sarkar - Public Redressal Portal Navigation Drawer tapped");

				app.Tap(_menuBtn);
				app.Tap(_JalyuktaShivarDFM);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Jalyukta Shivar - Drought-free Maharashtra Navigation Drawer tapped");

				app.Tap(_menuBtn);
				app.Tap(_SwachhMaharashtra);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Swachh Maharashtra Navigation Drawer tapped");

				app.Tap(_menuBtn);
				app.Tap(_MakeinMaharashtra);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Make in Maharashtra Navigation Drawer tapped");

				app.Tap(_menuBtn);
				app.Tap(_SkillDevelopment);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Skill Development Navigation Drawer tapped");

				app.Tap(_menuBtn);
				app.Tap(_RighttoService);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Right To Service Navigation Drawer tapped");

				app.Tap(_menuBtn);
				app.Tap(_DigitalMaharashtra);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Digital Maharashtra Navigation Drawer tapped");

				app.Tap(_menuBtn);
				app.Tap(_CMMedicalAssistanceCell);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Chief Minister's Medical Assistance Cell Navigation Drawer tapped");


			}
			catch(Exception ex)
			{
				Assert.Fail("Error occur on Initiatives Page " + ex.Message);
			}
			return ErrorMessage;
		}



		public string Initiative()
		{
			try
			{
				app.Tap(_Initiatives);
				app.WaitForElement(_AapleSarkarPRP, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Initiatives Page");

				app.Tap(_AapleSarkarPRP);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Aaple Sarkar - Public Redressal Portal page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Aaple Sarkar - Public Redressal Portal page Header back tapped");

				app.Tap(_JalyuktaShivarDFM);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Jalyukta Shivar - Drought-free Maharastra page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Jalyukta Shivar - Drought-free Maharashtra page Header back tapped");

				app.Tap(_SwachhMaharashtra);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Swachh Maharashtra Page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Swachh Maharashtra Page Header back tapped");

				app.ScrollDown();
				app.Screenshot("Initiatives page Scrolled Down");

				app.Tap(_MakeinMaharashtra);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Make in Maharashtra page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Make in Maharastra page Header back tapped");

				app.Tap(_SkillDevelopment);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Skill Development page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Skill Development page Header back tapped");

				app.Tap(_RighttoService);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Right To Service page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Right To Service Page Header back tapped");

				app.Tap(_DigitalMaharashtra);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Digital Maharashtra page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Digital Maharashtra page Header back tapped");

				app.Tap(_CMMedicalAssistanceCell);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(15));
				app.Screenshot("Chief Minister's Medical Assistance Cell page");

				app.Tap(_menuBtn);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("Meet the Chief Minister page");

				app.Back();
				app.WaitForElement(_Initiatives,"",TimeSpan.FromSeconds(5));


			}
			catch (Exception ex) { Assert.Fail("Error occur on Initiatives Page " + ex.Message); }
			return ErrorMessage;
		}


	}
}
