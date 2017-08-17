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
	public class CMOffice : BasePage
	{

		public string ErrorMessage = string.Empty;
		readonly Query _menuBtn;
		readonly Query _CMOffice;
		readonly Query _CMOfficeHomePage;

		//Team CMO
		#region
		readonly Query _teamCMO;

		#endregion

		//Former Maharashtra Chief Minister
		#region
		readonly Query _FMCM;

		#endregion


		//Contact the CMO
		#region
		readonly Query _ContactCMO;
		readonly Query _Name;
		readonly Query _Email;
		readonly Query _Mobile;
		readonly Query _Subject;
		readonly Query _messageBox;
		readonly Query _submitBtn;
		readonly Query _errName;
		readonly Query _errEmail;
		readonly Query _errMobileNumber;
		readonly Query _errSubject;
		readonly Query _errMsg;
		readonly Query _okBtn;
		readonly Query _phNo1;
		readonly Query _phNo2;
		readonly Query _FaxNo;
		readonly Query _emailid;
		#endregion

		public CMOffice(IApp app, Platform platform)
						: base(app, platform)
		{
			//if (OnAndroid)
			//{
				_menuBtn = x => x.Marked("Navigate up");
				_CMOffice = x => x.Marked("CM'S OFFICE");
				_CMOfficeHomePage = x => x.Marked("ABannerButton_Container");

				//Team CMO
				#region
				_teamCMO = x => x.Marked("lbl_TeamCMO");
				#endregion

				//Former Maharashtra Chief Minister
				#region
				_FMCM = x => x.Marked("lbl_FormerCMs");
				#endregion

				//Contact the CMO
				#region
				_ContactCMO = x => x.Marked("lbl_ContactCMO");
				_Name = x => x.Marked("txt_name");
				_Email = x => x.Marked("txt_Email");
				_Mobile = x => x.Marked("txt_mobile");
				_Subject = x => x.Marked("txt_subject"); 
				_messageBox = x => x.Marked("txt_Message");
				_submitBtn = x => x.Marked("SUBMIT");
				_errName = x => x.Marked("message").Text("Please enter valid Name.");
				_errEmail = x => x.Marked("message").Text("Please enter valid Email Address.");
				_errMobileNumber = x => x.Marked("message").Text("Please enter valid Mobile Number.");
				_errSubject = x => x.Marked("message").Text("Please enter valid Subject.");
				_errMsg  = x => x.Marked("message").Text("Please enter valid Message.");
				_okBtn = x => x.Marked("button2");
				_phNo1 = x => x.Marked("OfficePhoneNumber1");
				_phNo2 = x => x.Marked("OfficePhoneNumber2");
				_FaxNo = x => x.Marked("OfficeFaxNumber");
				_emailid = x => x.Marked("OfficeEmail");
				#endregion

			//}
		}

		public string TeamCMO()
		{
			try 
			{
				//app.Repl();
				//Tap CM Office Button
				app.Tap(_CMOfficeHomePage);
				app.WaitForElement(_menuBtn, "", TimeSpan.FromSeconds(10));
				app.Screenshot("CM Office Button Selected");

				//app.Repl();

				app.Tap(_menuBtn);
				app.WaitForElement(_CMOffice,"",TimeSpan.FromSeconds(10));
				app.Screenshot("Menu tapped");

				app.Tap(_CMOffice);
				app.WaitForElement(_CMOffice,"",TimeSpan.FromSeconds(5));
				app.Screenshot("CM's Office tapped");

				app.Tap(_teamCMO);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Team CMO page");
			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Team CMO Page " + ex.Message); 
			}
			return ErrorMessage;
		}

		public string FormerMaharashtraCM()
		{
			try
			{
				app.Tap(_menuBtn);
				app.WaitForElement(_CMOffice,"",TimeSpan.FromSeconds(5));
				app.Screenshot("CM's Office tapped");
				app.Tap(_FMCM);
				app.WaitForElement(_menuBtn,"",TimeSpan.FromSeconds(5));
				app.Screenshot("Former Maharashtra Chief Minister page");

			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Former Maharashtra Chief Minister Page " + ex.Message);
			}
			return ErrorMessage;		}

		//Normal Testing
		public string ContactTheCMO()
		{
			try
			{

				app.Tap(_menuBtn);
				app.WaitForElement(_CMOffice,"",TimeSpan.FromSeconds(5));
				app.Screenshot("CM's Office tapped");

				app.Tap(_ContactCMO);
				app.WaitForElement(_submitBtn,"",TimeSpan.FromSeconds(3));
				app.Screenshot("Contact the CMO page");

				app.Tap(_submitBtn);
				//app.WaitForElement(_okBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Enter Name Popup");
				app.Tap(_okBtn);
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("OK button Tapped");

				app.Tap(_Name);
				app.EnterText("Test1");
				app.Screenshot("Name Entered ");
				app.DismissKeyboard();
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));

				app.Tap(_submitBtn);
				//app.WaitForElement(_okBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Enter Email Popup");
				app.Tap(_okBtn);
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("OK button Tapped");

				app.Tap(_Email);
				app.EnterText("abc@test.com");
				app.Screenshot("EmailID Entered ");
				app.DismissKeyboard();
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));

				app.Tap(_submitBtn);
				//app.WaitForElement(_okBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Enter Mobile Number Popup");
				app.Tap(_okBtn);
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("OK button Tapped");


				app.Tap(_Mobile);
				app.EnterText("0123456789");
				app.Screenshot("Mobile Number Entered");
				app.DismissKeyboard();
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));

				app.Tap(_submitBtn);
				//app.WaitForElement(_okBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Enter Subject Popup");
				app.Tap(_okBtn);
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("OK button Tapped");

				app.Tap(_Subject);
				app.EnterText("Testing");
				app.Screenshot("Subject Entered");
				app.DismissKeyboard();
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));

				app.Tap(_messageBox);
				app.EnterText("Test123");
				app.Screenshot("Text Entered in Message text Box");
				app.DismissKeyboard();
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));

				app.Tap(_submitBtn);
				//app.WaitForElement(_okBtn, "", TimeSpan.FromSeconds(5));
				app.Screenshot("Message Box Popup");

				app.Tap(_okBtn);
				app.WaitForElement(_submitBtn, "", TimeSpan.FromSeconds(3));
				app.Screenshot("Error Message Box Ok Button tapped");

				app.ScrollDown();

				app.Tap(_phNo1);
				app.Screenshot("First Phone Number Tapped");
				app.Tap(_okBtn);


				app.Tap(_phNo2);
				app.Screenshot("Second Phone Number Tapped");
				app.Tap(_okBtn);

				//app.Tap(_FaxNo);
				//app.Screenshot("Fax Number Tapped");

				//app.Tap(_emailid);
				//app.Screenshot("Email ID Tapped");



			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Contact The CMO Page " + ex.Message);
			}
			return ErrorMessage;
		}

		//Contact CMO Validation Testing 
		public string ContactCMOValidationTesting()
		{
			try 
			{
				
			}
			catch (Exception ex)
			{
				Assert.Fail("Error occur in Contact The CMO Validation Testing" + ex.Message);
			}
			return ErrorMessage;
		}

	}
}
